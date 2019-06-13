using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Entities;

namespace SIMSInterface
{
    public class EditSENStudent
    {
        public static void UpdateStudent()
        {
            // need to ask Harry about the structure
            // for check detail please have a alook on Chris Aaron

            SIMS.Processes.SENCache.Populate();
            var list = GroupCache.SENStatuses;
            var provisionTypes = SENCache.SENProvisionTypes;

            SIMS.Processes.EditSENStudent editProcess = new SIMS.Processes.EditSENStudent();
            SIMS.Entities.IIDEntity iDEntity = new Person(12105);
            
            editProcess.Load(iDEntity, DateTime.Now);


            //SENNeed
            SENNeed newNeed = editProcess.GetNewNeed(); //auto set max rank
            newNeed.NeedType = (SENNeedType) SENCache.SENNeedTypes.Item(0);
            newNeed.NeedStartDate= DateTime.Now;
            newNeed.NeedEndDate = DateTime.Now;
            //newNeed.ChangeRanking(1);
            
            editProcess.Student.SENNeeds.Add(newNeed);
            editProcess.Student.SENStatusStartDate = DateTime.Now;
            //editProcess.GridStudentItem.SENProvisions.Add(new SENProvision
            //{
            //    ProvisionType = (SENProvisionType) provisionTypes.Item(0)
            //});
            
            editProcess.Student.SENStatus = GroupCache.SENStatuses.Item(0);
            //editSENStudent.GridStudentItem.SENNeeds = 

            //editSENStudent.SENStatusHistoryLogs?.Add(new SENStatusHistory
            //{
            //    SENStatusStartDate = DateTime.Now,
            //    SENStatusEndDate = DateTime.Now,
            //    SENStatus = GroupCache.SENStatuses.Item(0)
            //});


            //SENNeedAuditLogs
            //editSENStudent.SENNeedChangeLogs.Add(new SENNeedChangeLog
            //{
                
            //});


            //editProcess.Save(DateTime.Now);
        }
    }
}


/*
 *
 *private void SetupSaveCommandParameters(
      DateTime effectiveDate,
      IDbCommand command,
      Documents studentDocuments)
    {
      command.CommandType = CommandType.StoredProcedure;
      DatabaseCommandCreator.addCommandParameter(command, "@person_id", (AbstractAttribute) this._student.PersonIDAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@sen_status_id", (AbstractAttribute) this._student.SENStatusAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@curriculum_teaching_methods", (AbstractAttribute) this._student.CurriculumTeachingMethodAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@grouping_support", (AbstractAttribute) this._student.GroupingSupportAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@specialised_resources", (AbstractAttribute) this._student.SpecialisedResourcesAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@advice_asessment", (AbstractAttribute) this._student.AdviceAsessmentAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@sen_status_start_date", (AbstractAttribute) this._student.SENStatusStartDateAttribute);
      DatabaseCommandCreator.addCommandParameter(command, "@effective_date", (object) effectiveDate);
      DatabaseCommandCreator.addCommandParameter(command, "@events_XML", (object) this._student.SENEvents.GetEventsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@event_persons_XML", (object) this._student.SENEvents.GetEventPersonsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@needs_XML", (object) this._student.SENNeeds.GetNeedsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@need_rank", (object) this._student.SENNeeds.GetNeedRankingsSaveData());
      DatabaseCommandCreator.addCommandParameter(command, "@reviews_XML", (object) this._student.SENReviews.GetReviewsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@review_participants_XML", (object) this._student.SENReviews.GetReviewParticipantsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@statements_XML", (object) this._student.SENStatements.GetStatementsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@provisions_XML", (object) this._student.SENProvisions.GetProvisionsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@provision_providers_XML", (object) this._student.SENProvisions.GetProvisionProvidersSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@related_others_XML", (object) this._student.SENRelatedOthers.GetRelatedOthersSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@ieps_XML", (object) this._student.SENIEPs.GetSENIEPsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@iep_targets_XML", (object) this._student.SENIEPs.GetSENIEPTargetsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@documents_XML", (object) studentDocuments.GetSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@udf_values_XML", (object) this._student.UDFValues.GetValuesSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gifts_talented_details_XML", (object) this._student.SENGiftedTalentedDetails.GetGiftedTalentedDetailsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gifts_XML", (object) this._student.SENGifts.GetGiftsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gift_provisions_XML", (object) this._student.SENGiftProvisions.GetProvisionsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gift_provision_providers_XML", (object) this._student.SENGiftProvisions.GetProvisionProvidersSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gift_events_XML", (object) this._student.SENGiftEvents.GetEventsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@gift_event_persons_XML", (object) this._student.SENGiftEvents.GetEventPersonsSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@linkedStudent_XML", (object) this._student.Agencies.GetLinkedAgencySaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@linkedAgent_XML", (object) this._student.LinkedAgents.GetLinkedOthersSaveXMLContent());
      DatabaseCommandCreator.addCommandParameter(command, "@senStatusChanged", (object) this._student.SENStatusAttribute.Changed());
      if (SystemConfigurationCache.LocaleCode.ToUpper() == "ENG" && SystemConfigurationCache.ExtendedRegionCode.ToUpper() == "ENG")
        DatabaseCommandCreator.addCommandParameter(command, "@ehcps_XML", (object) this._student.EHCPs.GetStatementsSaveXMLContent());
      else
        DatabaseCommandCreator.addCommandParameter(command, "@ehcps_XML", (object) DBNull.Value);
    }
 *
 */


/*
 *
 *   private void bindControlsToAttributes()
   {
     this.setAttribute((ISIMSControl) this.comboBoxStatus, (AbstractAttribute) this.editProcess.GridStudentItem.SENStatusAttribute);
     this.setAttribute((ISIMSControl) this.comboBoxCurriculumandTeachingMethods, (AbstractAttribute) this.editProcess.GridStudentItem.CurriculumTeachingMethodAttribute);
     this.setAttribute((ISIMSControl) this.comboBoxGroupingandSupport, (AbstractAttribute) this.editProcess.GridStudentItem.GroupingSupportAttribute);
     this.setAttribute((ISIMSControl) this.comboBoxSpecialisedResources, (AbstractAttribute) this.editProcess.GridStudentItem.SpecialisedResourcesAttribute);
     this.setAttribute((ISIMSControl) this.comboBoxAdviceandAssessment, (AbstractAttribute) this.editProcess.GridStudentItem.AdviceAsessmentAttribute);
     this.setAttribute((ISIMSControl) this.textBoxStatusStartDate, (AbstractAttribute) this.editProcess.GridStudentItem.SENStatusStartDateAttribute);
     this.setAttribute((ISIMSControl) this.maintainedListViewOverview, (AbstractAttribute) this.editProcess.GridStudentItem.SENOverviews);
     this.setAttribute((ISIMSControl) this.maintainedListViewNeeds, (AbstractAttribute) this.editProcess.GridStudentItem.SENNeeds);
     this.setAttribute((ISIMSControl) this.maintainedListViewEvents, (AbstractAttribute) this.editProcess.GridStudentItem.SENEvents);
     this.setAttribute((ISIMSControl) this.maintainedListViewReviews, (AbstractAttribute) this.editProcess.GridStudentItem.SENReviews);
     this.setAttribute((ISIMSControl) this.maintainedListViewStatements, (AbstractAttribute) this.editProcess.GridStudentItem.SENStatements);
     this.setAttribute((ISIMSControl) this.maintainedListViewEHCPs, (AbstractAttribute) this.editProcess.GridStudentItem.EHCPs);
     this.setAttribute((ISIMSControl) this.maintainedListViewIEPs, (AbstractAttribute) this.editProcess.GridStudentItem.SENIEPs);
     this.setAttribute((ISIMSControl) this.maintainedListViewProvisions, (AbstractAttribute) this.editProcess.GridStudentItem.SENProvisions);
     this.setAttribute((ISIMSControl) this.documentListViewFullDescs, (AbstractAttribute) new IDocumentLinkedEntityAttribute((IDocumentLinkedEntity) this.editProcess.GridStudentItem.FullDescriptions));
     this.documentListViewFullDescs.InfomationDomain = InformationDomainEnum.SencoBasic;
     this.setAttribute((ISIMSControl) this.SENdocumentListControl, (AbstractAttribute) new IDocumentLinkedEntityAttribute((IDocumentLinkedEntity) this.editProcess.GridStudentItem.FullDescriptions));
     this.RefreshGiftsandTalentsListview();
   }
 *
 */
