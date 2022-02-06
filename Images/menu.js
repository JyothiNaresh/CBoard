function fwLoadMenus() {
  if (window.fw_menu_0) return;
  
  window.fw_menu_0_1 = new Menu("Pure Masters",160,18,"Arial",11);
  fw_menu_0_1.addMenuItem("Company Details","window.open('CompanyDetails.aspx?FormId=Company','MainTextPart')");
  fw_menu_0_1.addMenuItem("Country Details","window.open('CountryDetails.aspx?FormId=Country','MainTextPart')");
  fw_menu_0_1.addMenuItem("State Details","window.open('StateDetails.aspx?From=State','MainTextPart')");
  fw_menu_0_1.addMenuItem("District Details","window.open('frm3DMastersDetails.aspx?From=DT','MainTextPart')");
  fw_menu_0_1.addMenuItem("Place Details","window.open('BranchDetails.aspx?From=Place','MainTextPart')");
  fw_menu_0_1.addMenuItem("Region Details","window.open('CountryDetails.aspx?FormId=Region','MainTextPart')");
  fw_menu_0_1.addMenuItem("Zone Details","window.open('CountryDetails.aspx?FormId=Zone','MainTextPart')");
  fw_menu_0_1.addMenuItem("Branch Details","window.open('BranchDetails.aspx?From=Branch','MainTextPart')");
  fw_menu_0_1.addMenuItem("College Details","window.open('CountryDetails.aspx?FormId=College','MainTextPart')");
  fw_menu_0_1.addMenuItem("Course Details","window.open('CountryDetails.aspx?FormId=Course','MainTextPart')");
  fw_menu_0_1.addMenuItem("Group Details","window.open('CountryDetails.aspx?FormId=Group','MainTextPart')");
  fw_menu_0_1.addMenuItem("Batch Details","window.open('CountryDetails.aspx?FormId=Batch','MainTextPart')");
  fw_menu_0_1.addMenuItem("Medium Details","window.open('CountryDetails.aspx?FormId=Medium','MainTextPart')");
  //fw_menu_0_1.addMenuItem("Student Type Details","window.open('CountryDetails.aspx?FormId=StuType','MainTextPart')");
  fw_menu_0_1.addMenuItem("Paymode Details","window.open('PayModeDetails.aspx?FormId=PayModeDt','MainTextPart')");
  fw_menu_0_1.addMenuItem("Concession Details","window.open('CountryDetails.aspx?FormId=Concession','MainTextPart')");
  fw_menu_0_1.addMenuItem("Payment Advices","window.open('CountryDetails.aspx?FormId=PayAdvice','MainTextPart')");
  fw_menu_0_1.addMenuItem("Payment Receipts","window.open('CountryDetails.aspx?FormId=PayReceipt','MainTextPart')");
  fw_menu_0_1.addMenuItem("Payorders","window.open('CountryDetails.aspx?FormId=PayOrder','MainTextPart')");
  fw_menu_0_1.addMenuItem("Coll Refundables","window.open('CountryDetails.aspx?FormId=CollRefund','MainTextPart')");
  fw_menu_0_1.addMenuItem("Coll Non-Refundables","window.open('CountryDetails.aspx?FormId=CollNonRefund','MainTextPart')");
  fw_menu_0_1.addMenuItem("User Types","window.open('CountryDetails.aspx?FormId=UserType','MainTextPart')");
  fw_menu_0_1.hideOnMouseOut=true;
  
  window.fw_menu_0_2 = new Menu("Mappings",160,18,"Arial",11);
  fw_menu_0_2.addMenuItem("Incharge Address Mapping","window.open('AddressMap.aspx?FormId=AddressMap','MainTextPart')");
  fw_menu_0_2.addMenuItem("Course-Group-Batch","window.open('frm3DMastersDetails.aspx?From=CGB','MainTextPart')");
  fw_menu_0_2.addMenuItem("Branch-wise Course","window.open('frm3DMastersDetails.aspx?From=BC','MainTextPart')");
  fw_menu_0_2.addMenuItem("Branch-Course-College","window.open('BranchCourseCollegeHome.aspx?FormId=BrCrCol','MainTextPart')");
  fw_menu_0_2.addMenuItem("Branch-wise Medium","window.open('frm3DMastersDetails.aspx?From=BM','MainTextPart')");
  fw_menu_0_2.addMenuItem("Line Category Details","window.open('frm3DMastersDetails.aspx?From=LCAT','MainTextPart')");
  fw_menu_0_2.hideOnMouseOut=true;
  
  window.fw_menu_0_3 = new Menu("AcademicYear-wise",175,18,"Arial",11);
  fw_menu_0_3.addMenuItem("Company Finance Details","window.open('CompanyFinYearDetails.aspx?FormId=ComFinYR','MainTextPart')");
  fw_menu_0_3.addMenuItem("Company AcademicYear Details","window.open('CompanyAcademicYearDetails.aspx?From=COMPANYACADEMICYEAR','MainTextPart')");
  fw_menu_0_3.addMenuItem("Tax Details","window.open('TaxDetails.aspx?FormId=Tax','MainTextPart')");
  fw_menu_0_3.addMenuItem("Branch-wise AcademicYear","window.open('BAcademicYearDetails.aspx?From=BAY','MainTextPart')");
  fw_menu_0_3.addMenuItem("Branch-wise AcademicYear Course","window.open('BAYCOURSEDetails.aspx?From=BAYC','MainTextPart')");
  fw_menu_0_3.addMenuItem("Branch Form Number Range","window.open('BAYearFormNoRange.aspx?From=RANGE','MainTextPart')");
  fw_menu_0_3.addMenuItem("Course Fee Master","window.open('CourseFeeHome.aspx?FormId=CourseFee','MainTextPart')");
  fw_menu_0_3.addMenuItem("Course Fee BreakUp","window.open('PayOrderDtHome.aspx?FormId=CourseFeeBreackUp','MainTextPart')");
  fw_menu_0_3.hideOnMouseOut=true;
  
  window.fw_menu_0 = new Menu("root",135,18,"Arial",11);
  
  fw_menu_0.addMenuItem(fw_menu_0_1);
  fw_menu_0.hideOnMouseOut=true;
  
  fw_menu_0.addMenuItem(fw_menu_0_2);
  fw_menu_0.hideOnMouseOut=true;
  
  fw_menu_0.addMenuItem(fw_menu_0_3);
  fw_menu_0.hideOnMouseOut=true;
  
  
  
  
  
  
  
  
  
  
/*  fw_menu_0.addMenuItem("Country Details","window.open('CountryDetails.aspx?FormId=Country','MainTextPart')");
  fw_menu_0.addMenuItem("Medium Details","window.open('CountryDetails.aspx?FormId=Medium','MainTextPart')");
  fw_menu_0.addMenuItem("Course Details","window.open('CountryDetails.aspx?FormId=Course','MainTextPart')");
  fw_menu_0.addMenuItem("Batch Details","window.open('CountryDetails.aspx?FormId=Batch','MainTextPart')");
   fw_menu_0.addMenuItem("Country Details","window.open('CountryDetails.aspx?FormId=Country','MainTextPart')");
  fw_menu_0.addMenuItem("Country Details","window.open('CountryDetails.aspx?FormId=Country','MainTextPart')");
  fw_menu_0.addMenuItem("Country Details","window.open('CountryDetails.aspx?FormId=Country','MainTextPart')");
  
  fw_menu_0.addMenuItem(fw_menu_0_1);
  fw_menu_0.hideOnMouseOut=true;
  fw_menu_0.addMenuItem("Zone Details","location='innerpage.html'");
  fw_menu_0.addMenuItem("Region Details","location='innerpage.html'");
  fw_menu_0.addMenuItem("Student Types","location='innerpage.html'");
  fw_menu_0.addMenuItem("Student Categories","location='innerpage.html'");
  
  */
     fw_menu_0.hideOnMouseOut=true;
	 fw_menu_0.childMenuIcon="Images1/arrows.gif";

  window.fw_menu_1 = new Menu("root",160,18,"Arial",11);
  fw_menu_1.addMenuItem("Sale of Applications","window.open('SOA/SOAHomePage.aspx?From=SOA','MainTextPart')");
  fw_menu_1.addMenuItem("Reservations","window.open('Reservations/ResHomePage.aspx?From=RES','MainTextPart')");
  fw_menu_1.addMenuItem("Reservation Cancellation","window.open('ReservationCancellation.aspx?From=RegCanHome','MainTextPart')");
  fw_menu_1.addMenuItem("Admissions","window.open('Admissions/AdmissionHomePage.aspx?From=ADM','MainTextPart')");
  fw_menu_1.addMenuItem("Collection Payment","window.open('CollectionPayments.aspx?From=COLLPAYMENT','MainTextPart')");
  fw_menu_1.addMenuItem("Collection Refund","window.open('CollectionRefund.aspx?From=COLLREFUND','MainTextPart')");
  fw_menu_1.addMenuItem("Student Transfer","window.open('StudentTransferNew.aspx?From=STUTRANSFER','MainTextPart')");
  fw_menu_1.addMenuItem("Student Closer","window.open('StudentCloserNew.aspx?From=STUCLOSE','MainTextPart')");
  fw_menu_1.addMenuItem("Account Transfer","window.open('StudentAcctTransferNew.aspx?From=AcctTransfer','MainTextPart')");
  fw_menu_1.addMenuItem("Account Update","window.open('StudentAccountUpdateHome.aspx?From=ACCTUPDATEHOME','MainTextPart')");
  fw_menu_1.hideOnMouseOut=true;


  fw_menu_1.writeMenus();
} 
