using System;
using System.Collections.Generic;

namespace TMPInterview.DbModels
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Firstname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int? UserId { get; set; }
        public DateTime? Birthday { get; set; }
        public int? ClientId { get; set; }
        public int? CreatorUserId { get; set; }
        public long? ModifiedByUserId { get; set; }
        public string? BloodType { get; set; }
        public double? HeightMetres { get; set; }
        public double? WeightKg { get; set; }
        public short CustomerTypeId { get; set; }
        public string? Gender { get; set; }
        public string? CompanyName { get; set; }
        public bool? SendPromoDetails { get; set; }
        public bool? SendBirthdayEmail { get; set; }
        public string? ActivateReward { get; set; }
        public decimal? PurchaseLimit { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? UniqueCustomerCode { get; set; }

        public virtual CustomerType CustomerType { get; set; } = null!;
    }
}
