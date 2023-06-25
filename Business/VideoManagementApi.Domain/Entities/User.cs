using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.ConfigureEntities;
using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public DateTime LastLogin { get; set; }
    public string? IpAddress { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public Guid? ProfilePictureId { get; set; }
    public ProfilePicture? ProfilePicture { get; set; }

    //Kullanıcının yorumları
    public ICollection<Comment> Comments { get; set; }
    //Kullanıcnın mentörlere yaptığı yorumlar
    public ICollection<UserAndOperationClaim> UserAndOperationClaims { get; set; }
    public ICollection<Report> Reports { get; set; }
    //Tokens
    public ICollection<AccessToken> AccessTokens { get; set; }
    //Kullanıcının ilgilendiği alanları kategorize etmek için
    public ICollection<UserAndCategory> UserAndCategories { get; set; }

}
