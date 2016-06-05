﻿using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Data
{
    class ListToXml
    {

        public void PersonalAccounts(PersonalAccount obj, string filePath)
        {

            var xmlser = new XmlSerializer(typeof(ObservableCollection<PersonalAccount>));
            ObservableCollection<PersonalAccount> list;
            try
            {
                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<PersonalAccount>;
                }
            }
            catch
            {
                list = new ObservableCollection<PersonalAccount>();
            }
            if (list == null) return;
            {
                list.Add(obj);
                using (Stream s = File.OpenWrite(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }

        }


        public void CompanyAccounts(CompanyAccount obj, string filePath)
        {
            var xmlser = new XmlSerializer(typeof(ObservableCollection<CompanyAccount>));
            ObservableCollection<CompanyAccount> list;
            try
            {

                using (Stream s = File.OpenRead(filePath))
                {
                    list = xmlser.Deserialize(s) as ObservableCollection<CompanyAccount>;
                }
            }
            catch
            {

                list = new ObservableCollection<CompanyAccount>();
            }
            if (list == null) return;
            {

                list.Add(obj);
                using (Stream s = File.OpenWrite(filePath))
                {
                    xmlser.Serialize(s, list);
                }
            }
        }
    }
}
