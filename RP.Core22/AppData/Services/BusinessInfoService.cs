
using Microsoft.Extensions.Options;
using RP.Core22.AppData.Models;
using System;
using System.Text.RegularExpressions;

namespace RP.Core22.AppData.Services
{
    public class BusinessInfoService
    {
        private readonly BusinessInfo _options;
        public BusinessInfoService(IOptions<BusinessInfo> options)
        {
            _options = options.Value;
        }

        public string BusinessName { get; set; }
        public string EMail { get; set; }

       public string GetFormattedPhone()
        {
            string international = "";
            string formattedNumber = "";
            if (!string.IsNullOrEmpty(_options.Telephone))
            {
                string phoneNumber = Regex.Replace(_options.Telephone, @"\s+", string.Empty);
                if (phoneNumber.Trim().Length > 10)
                {
                    //This is an international number ie. 61 02 1234 5678

                    string CountryCode = "+" + string.Format("({0:(##)})", phoneNumber.Substring(0, 2));
                    string AreaCode = string.Format("({0})", phoneNumber.Substring(2, 2));

                    string LocalNumber = string.Format(" {0} {1}", phoneNumber.Substring(4, 4), phoneNumber.Substring(8));
                    formattedNumber = AreaCode + LocalNumber;

                    international = CountryCode + string.Format(" {0}", Convert.ToInt64(phoneNumber.Substring(2, 2))) + LocalNumber;

                }
                else if ((phoneNumber.Trim().Length <= 10) && (phoneNumber.Trim().Length > 8))
                {
                    //This is a local number ie. 02 1234 1234
                    string AreaCode = string.Format("({0:(##)})", phoneNumber.Substring(0, 2));
                    string LocalNumber = string.Format("{0} {1}", phoneNumber.Substring(2, 4), phoneNumber.Substring(6));
                    formattedNumber = AreaCode + LocalNumber;

                }
                else
                {
                    formattedNumber = phoneNumber;
                }
            }
            return formattedNumber;
        }


        /// <summary>
        /// Format Phone Number
        /// </summary>
        /// <param name="phoneNumber">Validated Phone Number</param>
        /// <param name="international">output international format</param>
        /// <returns>Local(Australian) phone format</returns>
        public static string getFormattedPhone(string phoneNumber, out string international)
        {
            international = "";
            string formattedNumber = "";
            if (!string.IsNullOrEmpty(phoneNumber))
            {

                phoneNumber = Regex.Replace(phoneNumber, @"\s+", string.Empty);

                if (phoneNumber.Trim().Length > 10)
                {
                    //This is an international number ie. 61 02 1234 5678

                    string CountryCode = "+" + string.Format("({0:(##)})", phoneNumber.Substring(0, 2));
                    string AreaCode = string.Format("({0})", phoneNumber.Substring(2, 2));

                    string LocalNumber = string.Format(" {0} {1}", phoneNumber.Substring(4, 4), phoneNumber.Substring(8));
                    formattedNumber = AreaCode + LocalNumber;

                    international = CountryCode + string.Format(" {0}", Convert.ToInt64(phoneNumber.Substring(2, 2))) + LocalNumber;

                }
                else if ((phoneNumber.Trim().Length <= 10) && (phoneNumber.Trim().Length > 8))
                {
                    //This is a local number ie. 02 1234 1234
                    string AreaCode = string.Format("({0:(##)})", phoneNumber.Substring(0, 2));
                    string LocalNumber = string.Format("{0} {1}", phoneNumber.Substring(2, 4), phoneNumber.Substring(6));
                    formattedNumber = AreaCode + LocalNumber;

                }
                else
                {
                    formattedNumber = phoneNumber;
                }
            }
            return formattedNumber;

        }

    }
}
