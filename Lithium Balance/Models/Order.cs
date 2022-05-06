﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Order : IPersistable
    {
        private string orderNumber;

        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Receiver { get; set; }
        public string LicenseDuration { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BMSType { get; set; }
        public string SoftwareVersion { get; set; }
        public string SoftwareType { get; set; }

        public Order(string orderNumber, string companyName, string receiver, string email, string bMSType, string softwareVersion, string softwareType, string licenseDuration, string address, string date)
        {
            OrderNumber = orderNumber;
            CompanyName = companyName;
            Receiver = receiver;
            Email = email;
            BMSType = bMSType;
            SoftwareVersion = softwareVersion;
            SoftwareType = softwareType;
            LicenseDuration = licenseDuration;
            Address = address;
            Date = date;
        }

        public Order()
        {
        }

        public void Parse(string line)
        {
            string[] data = line.Split(';');
            OrderNumber = data[0];
            CompanyName = data[1];
            Receiver = data[2];
            LicenseDuration = data[3];
            Date = data[4];
            Email = data[5];
            Address = data[6];
            BMSType = data[7];
            SoftwareVersion = data[8];
            SoftwareType = data[9];
        }

        public string Format()
        {
            return $"{OrderNumber};{CompanyName};{Receiver};{LicenseDuration};{Date};{Email};{Address};{BMSType};{SoftwareVersion},{SoftwareType}";
        }
    }
}
