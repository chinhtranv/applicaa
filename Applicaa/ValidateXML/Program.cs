using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using FluentValidation.Results;
using ValidateXML.Validation;


namespace ValidateXML
{
    class Program
    {
        public static List<string> ErrorMessages { get; set; }

        static void Main(string[] args)
        {
            ErrorMessages = new List<string>();
            
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Starting validate : ATFFile");
            ValidateATFFile("ATFile");

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Starting validate : ATFile_EmptyError2");
            ValidateATFFile("ATFile_EmptyError2");
            //ValidateATFFile("ATFile_EmptyError2");
            //GenerateAssessmentXMLFile();
            

            Console.WriteLine("- DONE -");
            Console.ReadLine();
        }

        private static void ValidateATFFile(string fileName)
        {            
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", path + "\\ATfile.xsd");
            var filePath = path + $"\\XmlFiles\\{fileName}.xml";

            
            //XmlReader rd = XmlReader.Create(filePath);
            //XDocument doc = XDocument.Load(rd);
            //doc.Validate(schema, ValidationEventHandler);


            var xmlContent = File.ReadAllText(filePath);
            var atf = XmlHelper.ConvertToObject<ATfile>(xmlContent,out var errorMessages);
            if (atf == null)
            {
                Console.WriteLine("Xml content is not valid");
                Console.WriteLine("Messages : " + errorMessages);
            }

            if (atf == null)
                return;

            //start validation
            var validator = new ATfileValidator();
            ValidationResult results = validator.Validate(atf);
            
            if (!results.IsValid)
            {
                Console.WriteLine("ATFile validation failed ...");
                foreach (var failure in results.Errors)
                {                    
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            else
            {
                bool flag = true;
                //if success the validate each pupil
                
                foreach (var atfPupil in atf.ATFpupilData)
                {
                    var pupilATfilePupiValidator = new ATfilePupiValidator();
                    ValidationResult pupilValidatorResult = pupilATfilePupiValidator.Validate(atfPupil);
                    if (!pupilValidatorResult.IsValid)
                    {
                        Console.WriteLine("Student "+ atfPupil.Forename + " " +atfPupil.Surname + " validation failed ...");
                        int index = 1;
                        foreach (var failure in pupilValidatorResult.Errors)
                        {
                            Console.WriteLine(index + " - Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                            index++;
                        }

                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Student has no error..");
                }
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    ErrorMessages.Add(e.Message);
                }
            }
        }



        private static void GenerateAssessmentXMLFile()
        {
            var now = DateTime.Now.ToShortDateString();

            var aspect = new ResultFileV7Aspect[1]
            {
                new ResultFileV7Aspect
                {
                    Name = "Aspect Name",
                    Supplier = "Supplier",
                    ExternalId = "ExternalId",
                    Module = "Module",
                    CreateDate = now,
                    EditDate = now,
                    SupplierRefId = "SupplierId",
                    RefId = "RefId",
                    ExporterRefId = "ExporterRefId",
                    GradesetExternalId = "GradesetExternalId",
                    Markset = new ResultFileV7AspectMarkset[1]
                    {
                        new ResultFileV7AspectMarkset
                        {
                            StartDate = new string[1] {now},
                            EndDate = new string[1] {now},
                        }
                    },
                    Description = "Description",
                    ColumnHeading = "ColumnHeading",
                    GradesetModule = "GradesetModule",
                    GradesetRefId = "GradesetRefId",
                    GradesetSupplier = "GradesetSupplier",
                    KeyStage1 = "KeyStage1",
                    KeyStage2 = "KeyStage2",
                    KeyStage3 = "KeyStage3",
                    Type = "Type",
                    ProgressGrid = "ProgressGrid"
                }
            };

            var gradeSetNode = new ResultFileV7Gradeset[1]
            {
                new ResultFileV7Gradeset
                {
                    Name = "Grade Set Name",
                    Supplier = "Supplier",
                    ExternalId = "ExternalId",
                    Module = "Module",
                    CreateDate = now,
                    EditDate = now,
                    Notes = "Notes",
                    SupplierRefId = "SupplierId",
                    RefId = "RefId",
                    ExporterRefId = "ExporterRefId",
                    GradesetHistory = new ResultFileV7GradesetGradesetHistory[1]
                    {
                        new ResultFileV7GradesetGradesetHistory
                        {
                            StartDate = now,
                            EndDate = now,
                            ValuesetAgency = "AGN",
                            Grade = new ResultFileV7GradesetGradesetHistoryGrade[1]
                            {
                                new ResultFileV7GradesetGradesetHistoryGrade
                                {
                                    Title = "Title",
                                    Color = "Red",
                                    Description = "Descrption",
                                    RankOrder = "1",
                                    Value = "AA"
                                }
                            }
                        }
                    },
                }
            };
            var resultNode = new ResultFileV7Result[1]
            {
                new ResultFileV7Result
                {
                    Module = "Module",
                    ExporterRefId = "ExporterRefId",
                    RefId = "RefId",
                    AspectExternalId = "AspectExternalId",
                    AspectModule = "AspectModule",
                    AspectRefId = "AspectRefId",
                    AspectSupplier = "AspectSupplier",
                    DOB = now,
                    Date = now,
                    Forename = "ForeName",
                    Gender = "Male",
                    LEANumber = "LEANumber",
                    ResultNotes = "Notes",
                    ResultValue = "AA",
                    ResultsetExternalId = "ExternalId",
                    ResultsetModule = "ResultSetMode",
                    ResultsetRefId = "ResultsetRefId",
                    ResultsetSupplier = "ResultsetSupplier",
                    School = "School",
                    SchoolNumber = "SchoolNumber",
                    Student = "Student",
                    Surname = "Surname"
                }
            };

            var resultSetNode = new ResultFileV7Resultset[1]
            {
                new ResultFileV7Resultset
                {
                    Name = "result Set Name",
                    CreateDate = now,
                    EditDate = now,
                    ExporterRefId = "ExporterRefId",
                    EndDate = now,
                    ResultsetSupplier = "ResultsetSupplier",
                    ResultsetRefId = "ResultsetRefId",
                    ResultsetModule = "ResultsetModule",
                    ResultsetExternalId = "ResultsetExternalId",
                    KeyStage = "KeyStage",
                    StartDate = now,
                    ResultsetSupplierRefId = "ResultsetSupplierRefId"
                }
            };

            var data = new ResultFileV7
            {
                AspectNode = aspect,
                Header = "Header",
                GradesetNode = gradeSetNode,
                ResultNode = resultNode,
                ResultsetNode = resultSetNode
            };
            var serializer = new XmlSerializer(typeof(ResultFileV7));
            using (var stream = new StreamWriter(@"D:\Uw\Applica\Src\applicaa\Applicaa\xmlForTest\test.xml"))
                serializer.Serialize(stream, data);
        }


    }
}
