using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace ValidateXML
{
    class Program
    {
        public static List<string> ErrorMessages { get; set; }

        static void Main(string[] args)
        {
            ErrorMessages = new List<string>();
            ValidateATFFile("ATfile");
            //GenerateAssessmentXMLFile();

            if (!ErrorMessages.Any())
            {
                Console.WriteLine("There are no error ... ");
            }
            else
            {
                foreach (var error in ErrorMessages)
                {
                    Console.WriteLine(error);
                }
            }

            Console.WriteLine("- DONE -");
            Console.ReadLine();
        }

        private static void ValidateATFFile(string fileName)
        {            
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", path + "\\ATfile.xsd");
            XmlReader rd = XmlReader.Create(path + $"\\{fileName}.xml");
            XDocument doc = XDocument.Load(rd);
            doc.Validate(schema, ValidationEventHandler);
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
