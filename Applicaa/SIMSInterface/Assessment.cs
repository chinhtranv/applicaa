using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SIMS.Entities;
using SIMS.Processes;
using SIMS.Processes.ThirdParty;

namespace SIMSInterface
{
    class Assessment
    {


        #region ASSESSMENT

        public static void Assessment_Export()
        {
            SIMSAssessmentMessage sdo = new SIMSAssessmentMessage();

            //ASSESSMENTRESULTCOMPONENT refers to Aspect
            //ASSESSMENTRESULTGRADESET refers to GradeSets
            //LEARNERASSESSMENTRESULTSET refers to ResultSets
            //LEARNERASSESSMENTRESULT refers to Results in SIMS Assessment Manager


            //noted : use homeSchoolId : 3a09f631-9103-47f1-8349-4be3438a3198

            //var x = GuidToSifRefID(new Guid("3a09f631-9103-47f1-8349-4be3438a3198")); //remove hyphen
            Dictionary<string, string> paramOptions = sdo.GetParamOptions(SIMSAssessmentMessage.ASSESSMENTRESULTCOMPONENT);


            // The parameter passed to GetParamOptions will vary
            // depending of what has been requested for export from Assessment
            // WriteBack interfaces.
            var xmlString = @"<SIMSAssessmentMessage>
                                    <Header>
                                        <MessageType>REQUEST</MessageType>
                                        <MessageID>895339910C94496AAD7C8C16C5E8F3CE</MessageID>
                                        <SourceID>PartnerTest</SourceID>
                                        <DestinationID>3A09F631910347F183494BE3438A3198</DestinationID>
                                    </Header>
                                    <QueryObject
                                        Type=""LEARNERASSESSMENTRESULTSET"">
                                        <RequestParameters />
                                    </QueryObject>
                                    </SIMSAssessmentMessage>";
            var request = new XmlDocument { InnerXml = xmlString };
            XmlDocument data = sdo.Export(request);

        }

        public static string GuidToSifRefID(Guid? guid)
        {
            if (!guid.HasValue)
                return (string)null;
            return guid.Value.ToString("N").ToUpper();
        }

        public void Assessment_Import()
        {
            SIMSAssessmentMessage sdo = new SIMSAssessmentMessage();
            Dictionary<string, string> paramOptions = sdo.GetParamOptions(SIMSAssessmentMessage.LEARNERASSESSMENTRESULT);

            // The parameter passed to
            // GetParamOptions will vary depending of what has been requested
            // for importing data using Assessment WriteBack interfaces.
            var xmlString = @"<?xml version=""1.0"" encoding=""UTF-8""
                                    standalone=""yes""?>
                                    <SIMSAssessmentMessage
                                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                    <Header>
                                    <MessageType>UPDATE</MessageType>
                                    <MessageID>4F59D43BE9EC41F2A11EBD247352ADC8</MessageID>
                                    <SourceID>PartnerTest</SourceID>
                                    <DestinationID>A7BCF7D4E4224965A153A3EDA4243601
                                    </DestinationID>
                                    <Status>OK</Status>
                                    </Header>
                                    <DataObjects>
                                    <LearnerAssessmentResult
                                    RefId=""0BD7DE6C0D824686A751AEA426228303""
                                    AssessmentComponentRefId=""48E292692A8842128D1E69ED707614ED""
                                    LearnerPersonalRefId=""884D121CE6E549F3A67858336FCD3086"">
                                    <SchoolInfoRefId>A7BCF7D4E4224965A153A3EDA4243601</SchoolInfoRefId>
                                    <AchievementDate>2009-08-26</AchievementDate>
                                    <Result>1</Result>
                                    <ResultStatus>R</ResultStatus>
                                    </LearnerAssessmentResult>
                                    </DataObjects>
                                    </SIMSAssessmentMessage>";
            var request = new XmlDocument();
            request.InnerText = xmlString;
            var rs = sdo.Import(request);

        }

        //API used internally by SIMS
        public static void AspectSummary()
        {
            string aspectname = "";
            string columnheader = "";
            string aspecttype = "u";
            int owner = 0;
            int module = 0;
            string category_xml = "<root></root>";
            string activeStatusCode = "";
            SIMS.Processes.AspectSummary asmAspectSummary = new AspectSummary();

            //[Obsolete("This method is deprecated and will not be available in future releases. Use the method PopulateAspects(string aspectName, string columnHeader, string aspectType, int owner, string category_xml, string activeStatusCode) instead.")]
            asmAspectSummary.PopulateAspects(aspectname, columnheader, aspecttype, owner, module, category_xml);

            //the error : Object not set reference is throwing ...
            //ASMAspectSummary.PopulateAspects(aspectname, columnheader, aspecttype, owner,category_xml,activeStatusCode);
        }

        public void MaintainAspect()
        {

            int personId = 447;
            SIMS.Processes.MaintainAspect asmMaintainAspect = new MaintainAspect();
            asmMaintainAspect.Populate(new SIMS.Entities.Person(personId));
            asmMaintainAspect.AspectEntity.AspectDescriptionAttribute.Value = "Dang 1";

            //saving AspectEntity
            bool isvalid = asmMaintainAspect.Valid();
            if (isvalid == true)
            {
                asmMaintainAspect.Save(new PerformanceCategorys());
            }
        }

        public static void MaintainGradesetsSummary()
        {
            int moduleID = 0;
            string suppliername = "";
            string gradesetName = "";

            SIMS.Processes.MaintainGradesetSummary asmMaintainGradeSetSummary = new MaintainGradesetSummary();
            asmMaintainGradeSetSummary.Populate(moduleID, suppliername, gradesetName);
            foreach (SIMS.Entities.ASMGradeSetSummary gradeSetSummary in asmMaintainGradeSetSummary.asmGradeSetSummarys)
            {
                //gradeSetSummary.NameAttribute;
                //gradeSetSummary.

            }
        }

        public void MaintainGradeSet()
        {
            int gradeSetId = 12;
            SIMS.Processes.MaintainGradeSet asmMaintainGradeSet = new MaintainGradeSet();
            asmMaintainGradeSet.Populate(gradeSetId);
            asmMaintainGradeSet.ASMGradeset.DescriptionAttribute.Value = "";

            //saving ASMGradeset Entity
            bool isvalid = asmMaintainGradeSet.Valid();
            if (isvalid == true)
            {
                asmMaintainGradeSet.Save();
            }
        }

        public static void GradesAndValues()
        {
            int gradeSetId = 12;
            SIMS.Processes.MaintainGradeSet asmMaintainGradeSet = new MaintainGradeSet();
            asmMaintainGradeSet.Populate(gradeSetId);
            foreach (SIMS.Entities.ASMGradeSetHistory asmGradeSetHistory in asmMaintainGradeSet.ASMGradeset.AsmGradesetHistorys.Value)
            {
                //insert code here to extract data
                //asmGradeSetHistory.ASMGradesValues
                //asmGradeSetHistory.GradesetID
            }

        }

        #endregion
    }
}
