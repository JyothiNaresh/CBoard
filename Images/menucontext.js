function showToolbar1()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("PureMasters", "Pure&nbsp;Masters", null,  null, null);
	
	//menu.addSubItem("PureMasters", "Sections", "Section",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=Section", "MainTextPart");
	//menu.addSubItem("PureMasters", "Sub sections", "Sub section",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=Subsection", "MainTextPart");
	//menu.addSubItem("PureMasters", "Caste", "Caste",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=Caste", "MainTextPart");
	menu.addSubItem("PureMasters", "Subjects", "Subjects",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=Subjects", "MainTextPart");
	//menu.addSubItem("PureMasters", "Exam Types", "Exam Types",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=ExamTypes", "MainTextPart");
	menu.addSubItem("PureMasters", "Tracks", "Tracks",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=Tracks", "MainTextPart");
	menu.addSubItem("PureMasters", "Previous Class", "Previous Class",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=PreviousCourse", "MainTextPart");
	menu.addSubItem("PureMasters", "Previous Type", "Previous Type",  "../Examination/FirstDCreation/FirstDCreationsDetails.aspx?From=PreviousType", "MainTextPart");
	menu.addSubItem("PureMasters", "P.c For P.c s",  " Previous Class For Present Class ",  "../Examination/RelationPCandPC/PCPresentCourseDetails.aspx?From=SubSection", "MainTextPart");	
	menu.addSubItem("PureMasters", "P.C.Subjects",  " Previous Class Subjects ",  "../Examination/PreviousCourseSubjects/PCSubjectsDetails.aspx?From=SubSection", "MainTextPart");	
	menu.addSubItem("PureMasters", "C.G.Subjects", "Class Group wise Subjects",  "../Examination/CGwiseSubject/CGWiseSubjectDetails.aspx?FormId=CGWS", "MainTextPart");
	menu.addSubItem("PureMasters", "Topics", "Topics",  "../Examination/Topics/TopicDetails.aspx", "MainTextPart");
	//menu.addSubItem("PureMasters", "Employee Master", "Employee Master",  "../Examination/FirstDCreation/EmpDetailSearch.aspx", "MainTextPart");
	menu.addSubItem("PureMasters", "ExamName Master", "ExamName Master",  "../Examination/ExamName/ExamNameDetail.aspx", "MainTextPart");	
	menu.addSubItem("PureMasters", "Combinations", "Combinations",  "../Examination/Cobinations/CombinationDetails.aspx", "MainTextPart");	
	
	menu.showMenu();
	menu.hideOnMouseOut=true;
}


function showToolbar2()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Mappings", "Mappings", null,  null, null);

	//menu.addSubItem("Mappings", "Incharge Address Mapping", null,  "AddressMap.aspx?FormId=AddressMap", "MainTextPart");
	menu.addSubItem("Mappings", "Exam Branches",  "Define Exam Branchs",  "../Examination/ExamBranchs/ExamBranchs.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "B.C Exam Branches",  "Branch & Class wise Exam Branchs",  "../Examination/ExamBranchs/BECDetails.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "Exam Branch Student",  "Exam Branch wise Student",  "../Examination/ExamBranchWiseStudent/EBWiseStudentDetails.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "Define Section",  "Defining Branch wise Section",  "../Examination/BRANCHSECTIONS/BACGBSectionDetails.aspx?From=Section", "MainTextPart");	
	menu.addSubItem("Mappings", "Student Section",  "Assigning Student to a Section",  "../Examination/StudentSection/StudentSectionDetails.aspx", "MainTextPart");		
	
	//menu.addSubItem("Mappings", "SubjectMapping",  "Subject Mapping ",  "../Examination/SubjectMapping/SubjectMap.aspx", "MainTextPart");

	///menu.addSubItem("Mappings", "Hostels",  " Branch wise Hostels",  "../Examination/Hostel/HostelDetails.aspx?From=BranchHostel", "MainTextPart");
	///menu.addSubItem("Mappings", "Blocks",  " Hotel wise Blocks",  "../Examination/Hostel/BBRDetails.aspx?From=HostelBlock", "MainTextPart");
	///menu.addSubItem("Mappings", "Rooms",  " Block wise Rooms",  "../Examination/Hostel/RoomsDetails.aspx?From=BlockRoom", "MainTextPart");
	///menu.addSubItem("Mappings", "Hostel In Charge",  " Hostel In Charge ",  "../Examination/Hostel/HostelInchargeDetails.aspx", "MainTextPart");
	///menu.addSubItem("Mappings", "Block Incharge",  " Block Incharge",  "../Examination/Hostel/BBREDetails.aspx?From=HostelBlockEmp", "MainTextPart");
	//menu.addSubItem("Mappings", "Block In Charge",  " Block In Charge ",  "../Examination/BranchBlockRoomEmp/BranchBlockRoomEmpDetails.aspx?From=HostelBlockEmp", "MainTextPart");
	///menu.addSubItem("Mappings", "Room In Charge",  " Room In Charge ",  "../Examination/Hostel/RoomEMPDetails.aspx?From=BlockRoomEmp", "MainTextPart");
			
	
	
	//menu.addSubItem("Mappings", "Branch Sub Section",  "Branch wise Sub Section",  "../Examination/BRANCHSECTIONS/BACGBSectionDetails.aspx?From=SubSection", "MainTextPart");	


	menu.addSubItem("Mappings", "Student Phone Nos",  " Student's Phone Nos ",  "../Examination/Student/StudentPhoneNos.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "Student HallTicketNos",  "Student HallTicketNos",  "../Examination/HallTicketNo/StudentsHallTicketNos.aspx", "MainTextPart");	
	//menu.addSubItem("Mappings", "Student's Address",  " Student's Address & Previows Course Marks ",  "../Examination/Student/StudentCastAddress.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Section In Charge",  " Section In Charge ",  "../Examination/SectionEmployees/SectionWiseEmployeDetails.aspx?From=Section", "MainTextPart");
	//menu.addSubItem("Mappings", "Subject Emp",  " Subject Wise Employees ",  "../Examination/BEMPLOYEESUBJECTS/BACGBSubjectEmployeesDetails.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "Students Caste ",  "Students' Caste ",  "../Examination/Student/StudentsCastevView.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Students DoB ",  "Students' DoB ",  "../Examination/Student/StudentDOB.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Students Pre.Marks",  "Students' Previous Marks ",  "../Examination/Student/PCMDetails.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Change PassWord",  "Change PassWord ",  "../Examination/ChangePassWord/ChangePwd.aspx?FromWhere=Menu", "MainTextPart");
	//menu.addSubItem("Mappings", "Subject Mapping",  "Subject Mapping ",  "../Examination/SubjectMapping/SubjectMap.aspx?FromWhere=Menu", "MainTextPart");
	
	//menu.addSubItem("Mappings", "Ques.Paper Type", "Ques.Paper Tyepe", "../Examination/EXAMMASS/ExamTypeWiseQuestionsDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Set",  "Create Set & Exam Mass",  "../Examination/EXAMMASS/ExamMassDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Category",  "Exam Category",  "../Examination/CTEXAM/CTExamDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Setup Exam Category",  "Exam Category Wise Sets & Question Paper Type",  "../Examination/ExamCateSetQpt/ExamSetQpt.aspx", "MainTextPart");
	
	//menu.addSubItem("Mappings", "Define Exam",  "Define Exam",  "../Examination/Exam/DefineExam.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Schedule",  "Exam Schedule",  "../Examination/ExamSchedules/ExamscheduleHome.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Student Details",  "Student Personal Details",  "../Examination/Student/AdmissionHomePage.aspx", "MainTextPart");
	
	menu.showMenu();
}

function showToolbar3()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("AcademicYear", "AcademicYear&nbsp;wise", null,  null, null);
	
    menu.addSubItem("AcademicYear", "Company Finance Details", null,  "CompanyFinYearDetails.aspx?FormId=ComFinYR", "MainTextPart");
   

	menu.showMenu();
}


function showToolbar4()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Transactions", "Transactions", null,  null, null);
	
	menu.addSubItem("Transactions", "Ques.Paper Type", "Ques.Paper Tyepe", "../Examination/EXAMMASS/ExamTypeWiseQuestionsDetails.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Exam Set",  "Create Set & Exam Mass",  "../Examination/EXAMMASS/ExamMassDetails.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Exam Category",  "Exam Category",  "../Examination/CTEXAM/CTExamDetails.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Setup Exam Category",  "Exam Category Wise Sets & Question Paper Type",  "../Examination/ExamCateSetQpt/ExamSetQpt.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Define Exam",  "Define Exam",  "../Examination/Exam/DefineExam.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Exam Dates",  "Subject Wise Exam Dates",  "../Examination/Exam/SubExamDates.aspx", "MainTextPart");
	
	menu.addSubItem("Transactions", "Exam Schedule",  "Exam Schedule",  "../Examination/ExamSchedules/ExamscheduleHome.aspx", "MainTextPart");
	menu.addSubItem("Transactions", "Student Details",  "Student Personal Details",  "../Examination/Student/AdmissionHomePage.aspx", "MainTextPart");
	
	
	menu.addSubItem("Transactions", "Set Tailor",  "Set Tailoring",  "../Examination/EXAMMASS/ExamMassTailor.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Que.Paper Tailor",  "Question Paper Tailor",  "../Examination/Exam/QPTTailor.aspx?FromMenu=QPTailor", "MainTextPart");
	menu.addSubItem("Transactions", "Key Entry",  "Question Paper Key Entry",  "../Examination/ExamSchedules/ExamQpUpload.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Key Comparision",  "Question Paper Key Comparision",  "../Examination/ExamSchedules/ExamTempQPComparison.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Key Upload",  "Question Paper Key Upload",  "../Examination/ExamSchedules/ExamQPMainUpload.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Obj. Results Upload",  "Students Objective Results Upload",  "../Examination/ExamSchedules/ObjectiveMarksEntry.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Des. Results Upload",  "Students Descriptive Results Upload",  "../Examination/ExamSchedules/DescriptiveMarksEntry.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Results Comparison",  "Students Results Comparison",  "../Examination/ExamSchedules/ExamQPResultComparison.aspx?FromWhere=Menu", "MainTextPart");
	//menu.addSubItem("Transactions", "Results Update",  "Students wise Results Update",  "../Examination/ExamSchedules/ExamResultsUpdate.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Transactions", "Key Update",  "Question Paper Update",  "../Examination/ExamSchedules/ExamQpKeyUpdate.aspx?FromWhere=Menu", "MainTextPart");
		
	//menu.addSubItem("Transactions", "Students Caste ",  "Students' Caste ",  "../Examination/Student/StudentsCastevView.aspx?FromWhere=Menu", "MainTextPart");
	

	menu.showMenu();
}


function showToolbar5()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Payments", "Payments", null,  null, null);
	
    menu.addSubItem("Payments", "Reservation Cancellation", null,  "ReservationCancellation.aspx?From=RegCanHome", "MainTextPart");

	menu.showMenu();
}

function showToolbar6()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Transfers", "Transfers", null,  null, null);
	
    menu.addSubItem("Transfers", "Student Transfer", null,  "StudentTransferNew.aspx?From=STUTRANSFER", "MainTextPart");

	menu.showMenu();
}


function showToolbar7()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Reports", "Reports", null,  null, null);
	menu.addSubItem("Reports","Section Wise Studetns", "Sewction Wise Students Reports", "../Examination/Reports/TextReports/TxtSectionWiseReports.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports"," Count ", " Branch Wise DOB Phone Caste Reports", "../Examination/Reports/TextReports/TxtDOBPHCACOUNT.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "DOB Count", "DOB Count",  "../Examination/Reports/TextReports/BranchWiseDobCount.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Pnone No Count", " Branch Wise Phone Nos Count ",  "../Examination/Reports/TextReports/TxtPhoneNo.aspx?From=MENU", "MainTextPart");
	//menu.addSubItem("Reports", "HallTicketNo Count", "HallTicketNo Count",  "../Examination/Reports/TextReports/ExamBranchHallTicket.aspx?From=MENU", "MainTextPart");
	//menu.addSubItem("Reports", "Caste Count", "Caste Count",  "../Examination/Reports/TextReports/BranchWiseCastCount.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Caste List", "Caste List",  "../Examination/Reports/TextReports/TxtBranchCaste.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Students DoB", "Studentes DoB",  "../Examination/Reports/TextReports/TxtRpStuDOB.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "HallTicketNo Summary", "HallTicketNo Summary",  "../Examination/Reports/TextReports/StudentHallTicketNoSummary.aspx?From=MENU", "MainTextPart");
	//menu.addSubItem("Reports", "Progress Report", null,  "../Examination/Reports/TextReports/ProgressRPT.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Progress Report", null,  "../Examination/Reports/TextReports/ProgressPRTBatch.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Student Enquiry", null,  "../Examination/Reports/TextReports/TxtRptStuEnquiry.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Toppers Report", null,  "../Examination/Reports/TextReports/TxtRptToppersList.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Results", null,  "../Examination/Reports/TextReports/Results.aspx?From=MENU", "MainTextPart");
    //menu.addSubItem("Reports", "Ranks", null,  "../Examination/Reports/TextReports/TxtRanks.aspx?From=MENU", "MainTextPart");
    //menu.addSubItem("Reports", "Comparative", null,  "../Examination/Reports/TextReports/TxtRptComparative.aspx?From=MENU", "MainTextPart");
   // menu.addSubItem("Reports", "Failures List", null,  "../Examination/Reports/TextReports/TxtRptFailureList.aspx?From=MENU", "MainTextPart");
     //menu.addSubItem("Reports", "Subject Wise Marks", "Subject Wise Marks",  "../Examination/Reports/TextReports/TxtTPTRSUBRPT.aspx?From=MENU", "MainTextPart");
       //CommanRPT.aspx    
    menu.addSubItem("Reports", "Subject Wise Marks", "Subject Wise Marks",  "../Examination/Reports/TextReports/CommanRPTBatch.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Pre.Course Marks", " Previous Course Marks ",  "../Examination/Reports/TextReports/TxtPreviousMarks.aspx?From=MENU", "MainTextPart");
       
       
	menu.showMenu();
}


function CentrelReports()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Reports", "Reports", null,  null, null);
	menu.addSubItem("Reports","Section Wise Studetns", "Sewction Wise Students Reports", "../Examination/Reports/TextReports/TxtSectionWiseReports.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports"," Count ", " Branch Wise DOB Phone Caste Reports", "../Examination/Reports/TextReports/TxtDOBPHCACOUNT.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "DOB Count", "DOB Count",  "../Examination/Reports/TextReports/BranchWiseDobCount.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Pnone No Count", " Branch Wise Phone Nos Count ",  "../Examination/Reports/TextReports/TxtPhoneNo.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "HallTicketNo Count", "HallTicketNo Count",  "../Examination/Reports/TextReports/ExamBranchHallTicket.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Caste Count", "Caste Count",  "../Examination/Reports/TextReports/BranchWiseCastCount.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Caste List", "Caste List",  "../Examination/Reports/TextReports/TxtBranchCaste.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Students DoB", "Studentes DoB",  "../Examination/Reports/TextReports/TxtRpStuDOB.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "HallTicketNo Summary", "HallTicketNo Summary",  "../Examination/Reports/TextReports/StudentHallTicketNoSummary.aspx?From=MENU", "MainTextPart");
	//menu.addSubItem("Reports", "Progress Report", null,  "../Examination/Reports/TextReports/ProgressRPT.aspx?From=MENU", "MainTextPart");
	 menu.addSubItem("Reports", "Progress Report", null,  "../Examination/Reports/TextReports/ProgressPRTBatch.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Student Enquiry", null,  "../Examination/Reports/TextReports/TxtRptStuEnquiry.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Toppers Report", null,  "../Examination/Reports/TextReports/TxtRptToppersList.aspx?From=MENU", "MainTextPart");
    menu.addSubItem("Reports", "Results", null,  "../Examination/Reports/TextReports/Results.aspx?From=MENU", "MainTextPart");
    //menu.addSubItem("Reports", "Ranks", null,  "../Examination/Reports/TextReports/TxtRanks.aspx?From=MENU", "MainTextPart");
    //menu.addSubItem("Reports", "Comparative", null,  "../Examination/Reports/TextReports/TxtRptComparative.aspx?From=MENU", "MainTextPart");
   // menu.addSubItem("Reports", "Failures List", null,  "../Examination/Reports/TextReports/TxtRptFailureList.aspx?From=MENU", "MainTextPart");
     //menu.addSubItem("Reports", "Subject Wise Marks", "Subject Wise Marks",  "../Examination/Reports/TextReports/TxtTPTRSUBRPT.aspx?From=MENU", "MainTextPart");
    //menu.addSubItem("Reports", "Subject Wise Marks", "Subject Wise Marks",  "../Examination/Reports/TextReports/CommanRPT.aspx?From=MENU", "MainTextPart");    
	menu.addSubItem("Reports", "Subject Wise Marks", "Subject Wise Marks",  "../Examination/Reports/TextReports/CommanRPTBatch.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "Pre.Course Marks", " Previous Course Marks ",  "../Examination/Reports/TextReports/TxtPreviousMarks.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "P.C.Marks Range", " Previous Course Marks Range Entry",  "../Examination/Reports/TextReports/PCMRANGE.aspx?From=MENU", "MainTextPart");
	menu.addSubItem("Reports", "P.C.Marks Range Rpt", " Previous Course Marks Range Report",  "../Examination/Reports/TextReports/TxtRangeAnalysis.aspx?From=MENU", "MainTextPart");
	menu.showMenu();
}


///THIS MENU FOR GUSER REQ. BY GURU & NIRU  ON 26/10/2005 Impby Surendar Reddy.A


function showToolbarGuser()
{
// AddItem(id, text, hint, location, alternativeLocation);
// AddSubItem(idParent, text, hint, location, linktarget);

	menu = new Menu();
	menu.addItem("Mappings", "Mappings", null,  null, null);

	//menu.addSubItem("Mappings", "Incharge Address Mapping", null,  "AddressMap.aspx?FormId=AddressMap", "MainTextPart");
	menu.addSubItem("Mappings", "Exam Branch Student",  "Exam Branch wise Student",  "../Examination/ExamBranchWiseStudent/EBWiseStudentDetails.aspx", "MainTextPart");

	menu.addSubItem("Mappings", "Hostels",  " Branch wise Hostels",  "../Examination/Hostel/HostelDetails.aspx?From=BranchHostel", "MainTextPart");
	menu.addSubItem("Mappings", "Blocks",  " Hotel wise Blocks",  "../Examination/Hostel/BBRDetails.aspx?From=HostelBlock", "MainTextPart");
	menu.addSubItem("Mappings", "Rooms",  " Block wise Rooms",  "../Examination/Hostel/RoomsDetails.aspx?From=BlockRoom", "MainTextPart");
	menu.addSubItem("Mappings", "Hostel In Charge",  " Hostel In Charge ",  "../Examination/Hostel/HostelInchargeDetails.aspx", "MainTextPart");
	menu.addSubItem("Mappings", "Block Incharge",  " Block Incharge",  "../Examination/Hostel/BBREDetails.aspx?From=HostelBlockEmp", "MainTextPart");
	//menu.addSubItem("Mappings", "Block In Charge",  " Block In Charge ",  "../Examination/BranchBlockRoomEmp/BranchBlockRoomEmpDetails.aspx?From=HostelBlockEmp", "MainTextPart");
	menu.addSubItem("Mappings", "Room In Charge",  " Room In Charge ",  "../Examination/Hostel/RoomEMPDetails.aspx?From=BlockRoomEmp", "MainTextPart");
	
	//menu.addSubItem("Mappings", "Exam Branches",  "Define Exam Branchs",  "../Examination/ExamBranchs/ExamBranchs.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "B.C Exam Branches",  "Branch & Class wise Exam Branchs",  "../Examination/ExamBranchs/BECDetails.aspx", "MainTextPart");
		
	
	//menu.addSubItem("Mappings", "Define Section",  "Defining Branch wise Section",  "../Examination/BRANCHSECTIONS/BACGBSectionDetails.aspx?From=Section", "MainTextPart");	
	//menu.addSubItem("Mappings", "Branch Sub Section",  "Branch wise Sub Section",  "../Examination/BRANCHSECTIONS/BACGBSectionDetails.aspx?From=SubSection", "MainTextPart");	

    menu.addSubItem("Mappings", "Student Section",  "Assigning Student to a Section",  "../Examination/StudentSection/StudentSectionDetails.aspx", "MainTextPart");		
    
	menu.addSubItem("Mappings", "Student Phone Nos",  " Student's Phone Nos ",  "../Examination/Student/StudentPhoneNos.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Student HallTicketNos",  "Student HallTicketNos",  "../Examination/HallTicketNo/StudentsHallTicketNos.aspx", "MainTextPart");	
	//menu.addSubItem("Mappings", "Student's Address",  " Student's Address & Previows Course Marks ",  "../Examination/Student/StudentCastAddress.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Section In Charge",  " Section In Charge ",  "../Examination/SectionEmployees/SectionWiseEmployeDetails.aspx?From=Section", "MainTextPart");
	menu.addSubItem("Mappings", "Students Caste ",  "Students' Caste ",  "../Examination/Student/StudentsCastevView.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Students DOB ",  "Students' DOB ",  "../Examination/Student/StudentDOB.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Students Pre.Marks",  "Students' Previous Marks ",  "../Examination/Student/PCMDetails.aspx?FromWhere=Menu", "MainTextPart");
	menu.addSubItem("Mappings", "Change PassWord",  "Change PassWord ",  "../Examination/ChangePassWord/ChangePwd.aspx?FromWhere=Menu", "MainTextPart");
	//menu.addSubItem("Mappings", "Sub Section In Charge",  " Sub Section In Charge ",  "../Examination/SectionEmployees/SectionWiseEmployeDetails.aspx?From=SubSection", "MainTextPart");
	//menu.addSubItem("Mappings", "Subject Emp",  " Subject Wise Employees ",  "../Examination/BEMPLOYEESUBJECTS/BACGBSubjectEmployeesDetails.aspx", "MainTextPart");
	
	//menu.addSubItem("Mappings", "Ques.Paper Type", "Ques.Paper Tyepe", "../Examination/EXAMMASS/ExamTypeWiseQuestionsDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Set",  "Create Set & Exam Mass",  "../Examination/EXAMMASS/ExamMassDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Category",  "Exam Category",  "../Examination/CTEXAM/CTExamDetails.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Setup Exam Category",  "Exam Category Wise Sets & Question Paper Type",  "../Examination/ExamCateSetQpt/ExamSetQpt.aspx", "MainTextPart");
	
	//menu.addSubItem("Mappings", "Define Exam",  "Define Exam",  "../Examination/Exam/DefineExam.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Exam Schedule",  "Exam Schedule",  "../Examination/ExamSchedules/ExamscheduleHome.aspx", "MainTextPart");
	//menu.addSubItem("Mappings", "Student Details",  "Student Personal Details",  "../Examination/Student/AdmissionHomePage.aspx", "MainTextPart");
		menu.showMenu();
}



