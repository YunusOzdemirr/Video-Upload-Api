using Microsoft.AspNetCore.Http;
using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Infrastructure.Utilities;

public class FileUpload
{
    private static string _currentDirectory = Environment.CurrentDirectory + @"/wwwroot/Uploads/";

    public static async Task<IResult> Upload(IFormFile file, string folderName)
    {
        var fileExists = await CheckFileExists(file);
        if (!fileExists.Succeeded)
            return fileExists;
        var type = Path.GetExtension(file.FileName);
        var typeValid =await CheckFileTypeValid(type);
        if (!typeValid.Succeeded)
            return typeValid;
        var randomName = Guid.NewGuid().ToString();
       await CheckDirectoryExists(_currentDirectory);
       await CreateImageFile(_currentDirectory + randomName + type, file);
        return await Result.SuccessAsync(
            (_currentDirectory + $"/{folderName}/" + randomName + type).Replace("\\", "/"), randomName + type + file);
    }

    public static async Task<IResult> UploadAlternative(IFormFile file, string folderName, string? oldFilePath = "")
    {
        if (!string.IsNullOrEmpty(oldFilePath) && oldFilePath != null && File.Exists(oldFilePath))
            File.Delete(oldFilePath);
        if (!Directory.Exists(_currentDirectory + folderName))
            Directory.CreateDirectory(_currentDirectory + folderName);

        string fileName = Guid.NewGuid().ToString();
        var path = _currentDirectory + folderName + @"/" + fileName;
        var virtualPath = "Uploads/" + folderName + "/" + fileName;
        var type = Path.GetExtension(file.FileName);
        var typeValid = await CheckFileTypeValid(type);
        if (!typeValid.Succeeded)
            return typeValid;

        await using (var stream = new FileStream(path, FileMode.Create))
            await file.CopyToAsync(stream);

        return await Result.SuccessAsync(virtualPath, path);
    }

    public static async Task<IResult> Update(IFormFile file, string folderName, string oldImageName)
    {
        var fileExists = await CheckFileExists(file);
        if (!fileExists.Succeeded)
            return await Result.FailAsync(fileExists.Message);
        var type = Path.GetExtension(file.FileName);
        var typeValid = await CheckFileTypeValid(type);
        if (!typeValid.Succeeded)
            return await Result.FailAsync(typeValid.Message);
        var randomName = Guid.NewGuid().ToString();

        await DeleteOldImageFile((_currentDirectory + $"\\{folderName}" + oldImageName).Replace("/", "\\"));
        await CheckDirectoryExists(_currentDirectory + $"\\{folderName}");
        await CreateImageFile(_currentDirectory + $"\\{folderName}" + randomName + type, file);
        return await Result.SuccessAsync((_currentDirectory + randomName + type).Replace("\\", "/"));
    }

    public static async Task<IResult> Delete(string path)
    {
        await DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
        return await Result.SuccessAsync("Başarıyla silindi.");
    }

    private static async Task<IResult> CheckFileExists(IFormFile file)
    {
        if (file != null && file.Length > 0)
            return await Result.SuccessAsync("Mevcut.");
        return await Result.FailAsync("Böyle bir dosya mevcut değil");
    }

    private static async Task<IResult> CheckFileTypeValid(string type)
    {
        type = type.ToLower();
        if (type == ".jpeg" || type == ".png" || type == ".jpg" || type==".dng"||type==".gif" || type==".mp4" || type==".m4a")
            return await Result.SuccessAsync("Geçerli dosya");
        return await Result.FailAsync("Dosya tipi yanlış formatta.");
    }

    private static Task CheckDirectoryExists(string directory)
    {
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        return Task.CompletedTask;
    }

    private static Task CreateImageFile(string directory, IFormFile file)
    {
        using (FileStream fs = File.Create(directory))
        {
            file.CopyTo(fs);
            fs.Flush();
        }

        return Task.CompletedTask;
    }

    private static Task DeleteOldImageFile(string directory)
    {
        if (File.Exists(directory.Replace("/", "\\")))
            File.Delete(directory.Replace("/", "\\"));
        return Task.CompletedTask;
    }
}