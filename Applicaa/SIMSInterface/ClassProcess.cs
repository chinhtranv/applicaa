using System;

namespace SIMSInterface
{
    public enum SchemeType
    {
        Bands,
        Block,
        Cluster,
        Alternative
    }

    public class ClassProcess
    {
        /// <summary>
        /// AttachClassToStudent
        /// </summary>
        /// <param name="schemeType"></param>
        /// <param name="schemaName"></param>
        /// <param name="admissionNumber"></param>
        /// <param name="className"></param>
        public static SimsResult AttachClassToStudent(string schemeType,string schemaName, string admissionNumber, string className)
        {
            SIMS.Processes.CurrCache.Populate();
            var scatter = new ExternalPopulation();
            string messages = string.Empty;
            bool success = false;
            if (scatter.LoadScheme(schemeType: schemeType, schemeName: schemaName))
            {
                scatter.Process.Strict = false;
                scatter.CreateMember(studentAdno: admissionNumber, groupName: className);
                scatter.Save();
                messages = "Attach student to class " + className + " successfully";
                success = true;
            }
            else
            {
                messages = "Could not load scheme : "+ schemaName + " - scheme Type : "+schemeType ;
            }

            if (success)
            {
                return new SimsResult
                {
                    Status = Status.Success,
                    Message = messages
                };
            }
            else
            {
                return new SimsResult
                {
                    Status = Status.Failed,
                    Message = messages
                };
            }
        }

        #region TESTING


        private void TestCreateMemberInClass()
        {
            //It will deal with schemes of all types (Bands, Blocks and Clusters) and will also allow non-eligible memberships to be created
            ExternalPopulation scatter = new ExternalPopulation();
            if (scatter.LoadScheme("Block", "10xy Option A"))
            {
                scatter.CreateMember("004604", "10A/Mu1");
                scatter.CreateMember("004605", "10A/Fr1");

                // this next student is not eligible, so need to set “Strict” to false.

                scatter.Process.Strict = false;
                scatter.CreateMember("004343", "10A/Mu1");
                scatter.Save();

            }

            if (scatter.LoadScheme("Block", "10xy Option B"))
            {
                scatter.CreateMember("004604", "10B/Ar1");
                scatter.Save();
            }

            if (scatter.LoadScheme("Cluster", "10B/Pt1"))
            {
                scatter.CreateMember("004604", "10B/Pt1");
                scatter.Save();
            }

        }

        #endregion

    }
}