﻿namespace PubsMartes.Api.Models.Core
{
    public class ModelBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
    }
}
