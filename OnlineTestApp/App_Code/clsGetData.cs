using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestApp.App_Code
{
    public class clsGetData
    {
        public clsGetData()
        {


            //
            // TODO: Add constructor logic here
            //
        }

        public string GetstrEmpty(object strData)
        {
            string StringData = string.Empty;
            try
            {
                StringData = Convert.ToString(strData);
                if (StringData == null)
                    StringData = "";
            }
            catch (Exception ex)
            {
                StringData = "";
            }
            return StringData;
        }

        public int GetInt_Zero(object data)
        {
            int intData = 0;
            try
            {
                intData = Convert.ToInt32(data);
            }
            catch (Exception ex) { }
            return intData;
        }

    }
}