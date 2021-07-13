using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string FacebookId { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LoginFailedDate { get; set; }
        public int LoginFailedCount { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string EmailConfirmationCode { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string ResetPasswordCode { get; set; }
        public DateTime? PhoneConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string PhoneConfirmationCode { get; set; }
        public DateTime? ResetPasswordRequestDate { get; set; }
        public int ResetPasswordCount { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string MobileDeviceToken { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string WebDeviceToken { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<Experience> Experiences { get; set; }
        public virtual IEnumerable<ExperienceMember> ExperienceMembers { get; set; }
        public virtual IEnumerable<Collectable> Collectables { get; set; }
        public virtual IEnumerable<RegionMember> RegionMembers { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<Reply> Replies { get; set; }
        public virtual IEnumerable<BankAccount> BankAccounts { get; set; }
        public virtual IEnumerable<DebitCard> DebitCards { get; set; }
        public virtual IEnumerable<RefreshToken> RefreshTokens { get; set; }


    }
}
