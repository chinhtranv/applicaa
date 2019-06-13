﻿using System;

namespace SIMSInterface
{
    public class ClassesMappingItem
    {
        public int BaseGroupId { get; set; }

        public string ClassName { get; set; }

        public string SchemaName { get; set; }

        public string SchemaType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? AdmissionClassId { get; set; }

        public string AdmissionClassName { get; set; }

        public string AdmissionClassCode { get; set; }
    }
}