using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SIMS.Processes;
using SIMS.Processes.ThirdParty;

namespace SIMSInterface
{
    public class SIMSAssessment
    {
        public static void Test_AssessmentResultComponent()
        {
            SIMSAssessmentMessage sdo = new SIMSAssessmentMessage();
            Dictionary<string, string> paramOptions = sdo.GetParamOptions(SIMSAssessmentMessage.ASSESSMENTRESULTCOMPONENT);

            // The parameter passed to GetParamOptions will vary
            //depending of what has been requested for export from Assessment
            //    WriteBack interfaces.
            string xml = @"<SIMSAssessmentMessage>
                                        <Header>
                                        <MessageType>REQUEST</MessageType>
                                        <MessageID>895339910C94496AAD7C8C16C5E8F3CE</MessageID>
                                        <SourceID>PartnerTest</SourceID>
                                        <DestinationID>A7BCF7D4E4224965A153A3EDA4243601</DestinationID>
                                        </Header>
                                        <QueryObject
                                        Type=""ASSESSMENTRESULTCOMPONENT"">
                                        <RequestParameters />
                                        </QueryObject>
                                        </SIMSAssessmentMessage>";
            XmlDocument request = new XmlDocument();
            request.InnerXml = xml;

            XmlDocument data = sdo.Export(request);

        }

        public static void Test_GradeSet()
        {

            ////The error document is present as sdo.ErrorDocument
            ////The error string is present as sdo.ErrorString
            //SIMS.Processes.EditSENReviewSource

            SIMS.Processes.MaintainGradeSet ASMMaintainGradeSet = new MaintainGradeSet();
            ASMMaintainGradeSet.Populate(12);
            foreach (SIMS.Entities.ASMGradeSetHistory asmGradeSetHistory in
                ASMMaintainGradeSet.ASMGradeset.AsmGradesetHistorys.Value)
            {
                //insert code here to extract data
                var gradeSet = asmGradeSetHistory;
            }

            bool isvalid = ASMMaintainGradeSet.Valid();
            if (isvalid == true)
            {
                ASMMaintainGradeSet.Save();
            }

        }

        public static void Test_AspectSummary()
        {
            string aspectname = "";
            string columnheader = "";
            string aspecttype = "u";
            int owner = 0;
            int module = 0;
            string category_xml = "<root></root>";
            SIMS.Processes.AspectSummary ASMAspectSummary = new AspectSummary();
            ASMAspectSummary.PopulateAspects(aspectname, columnheader, aspecttype, owner, module, category_xml);
        }
    }
}
