<%@ Control Language="vb" AutoEventWireup="false" Codebehind="UCResultDetailsSelection.ascx.vb" Inherits="CollegeBoard.UCResultDetailsSelection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
<table id="Table1" style="WIDTH: 900px; HEIGHT: 16px" cellSpacing="0" cellPadding="0" width="784"
	align="center" border="1">
	<tr>
		<td>
			<table width="50%" align="center" border="1">
				<tr>
					<td width="15%"><asp:label id="Label5" Height="10px" runat="server" CssClass="Lables">Result&nbsp;Exam&nbsp;Type:</asp:label></td>
					<td width="15%"><asp:dropdownlist id="DrpResultExamType" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td width="15%"><asp:label id="Label4" Height="10px" runat="server" CssClass="Lables">Result&nbsp;Exam&nbsp;Name:</asp:label></td>
					<td width="15%"><asp:dropdownlist id="DrpResultExam" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td><asp:panel id="PnlIIT" runat="server" CssClass="Panels" BackColor="#EBDED6" HorizontalAlign="Center"
				ForeColor="#663300" Font-Bold="True" Visible="False">IIT-RESULT 
      <TABLE width="100%">
					<TR>
						<TD width="13%">
							<asp:CheckBox id="IIT_TOTALRANK" runat="server" CssClass="lables" Checked="True" Text="MainRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="IIT_CATRANK" runat="server" CssClass="lables" Text="CatRank" Width="100%"></asp:CheckBox></TD>
						<TD width="13%">
							<asp:CheckBox id="IIT_CATSUBPCRANK" runat="server" CssClass="lables" Text="PcRank" Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="IIT_CATSUBPTRANK" runat="server" CssClass="lables" Text="PtRank" Width="100%"></asp:CheckBox></TD>
						<TD width="13%">
							<asp:CheckBox id="IIT_PREPARATORYRANK" runat="server" CssClass="lables" Text="PDRank" Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="IIT_ISPREPARATORYRANK" runat="server" CssClass="lables" Text="Preporatory" Width="100%"></asp:CheckBox></TD>
						<TD width="13%">
							<asp:CheckBox id="IIT_PAPERWISE" runat="server" CssClass="lables" Text="PaperWise" Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:DropDownList id="IIT_EML" runat="server" Width="100%" Enabled="False">
								<asp:ListItem Value="0" Selected="True">WithOutEML</asp:ListItem>
								<asp:ListItem Value="2">OnlyEML</asp:ListItem>
								<asp:ListItem Value="0">Both</asp:ListItem>
							</asp:DropDownList></TD>
					</TR>
				</TABLE></asp:panel><asp:panel id="PnlAIEEE" runat="server" CssClass="Panels" BackColor="#EBDED6" HorizontalAlign="Center"
				ForeColor="#663300" Font-Bold="True" Visible="False">AIEEE-RESULT 
      <TABLE width="100%">
					<TR>
						<TD width="10%">
							<asp:Label id="Label1" runat="server" CssClass="lables" Font-Bold="True">B.Tech</asp:Label></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BTECHTOTAL" runat="server" CssClass="lables" Checked="True" Text="BTTotal"
								Width="100%"></asp:CheckBox></TD>
						<TD width="16%">
							<asp:CheckBox id="AIE_BTECHAIR" runat="server" CssClass="lables" Checked="True" Text="BTAllIndiaRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BTECHSR" runat="server" CssClass="lables" Text="BTStateRank" Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BTECHCATRANKAIR" runat="server" CssClass="lables" Text="BTCat-AllIndiaRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BTECHCATRANKSR" runat="server" CssClass="lables" Text="BTCat-StateRank"
								Width="100%"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD width="10%">
							<asp:Label id="Label2" runat="server" CssClass="lables" Font-Bold="True">B.Arch</asp:Label></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BRACHTOTAL" runat="server" CssClass="lables" Checked="True" Text="BATotal"
								Width="100%"></asp:CheckBox></TD>
						<TD width="16%">
							<asp:CheckBox id="AIE_BRACHAIR" runat="server" CssClass="lables" Checked="True" Text="BAAllIndiaRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BRACHSR" runat="server" CssClass="lables" Text="BAStateRank" Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BARCHCATRANKAIR" runat="server" CssClass="lables" Text="BACat-AllIndiaRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BARCHCATRANKSR" runat="server" CssClass="lables" Text="BACat-StateRank"
								Width="100%"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD width="10%">
							<asp:Label id="Label3" runat="server" CssClass="lables" Font-Bold="True">B.Pharm</asp:Label></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BPHARTOTAL" runat="server" CssClass="lables" Text="BPTotal" Width="100%"></asp:CheckBox></TD>
						<TD width="16%">
							<asp:CheckBox id="AIE_BPHARAIR" runat="server" CssClass="lables" Text="BPAllIndiaRank" Width="100%"></asp:CheckBox></TD>
						<TD width="17%">
							<asp:CheckBox id="AIE_BPHARSR" runat="server" CssClass="lables" Text="BPStateRank" Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BPHARCATRANKAIR" runat="server" CssClass="lables" Text="BPCat-AllIndiaRank"
								Width="100%"></asp:CheckBox></TD>
						<TD width="20%">
							<asp:CheckBox id="AIE_BPHARMCATRANKSR" runat="server" CssClass="lables" Text="BPCat-StateRank"
								Width="100%"></asp:CheckBox></TD>
					</TR>
				</TABLE></asp:panel><asp:panel id="PnlEAMCET" runat="server" CssClass="Panels" BackColor="#EBDED6" HorizontalAlign="Center"
				ForeColor="#663300" Font-Bold="True" Visible="False">EAMCET-RESULT 
      <TABLE width="100%">
					<TR>
						<TD width="13%">
							<asp:CheckBox id="EAM_TOTALMARKS" runat="server" CssClass="lables" Checked="True" Text="Eam_Tot"
								Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="EAM_EAM_WT" runat="server" CssClass="lables" Checked="True" Text="Eam_Wt" Width="100%"></asp:CheckBox></TD>
						<TD width="13%">
							<asp:CheckBox id="EAM_IPE_GT" runat="server" CssClass="lables" Checked="True" Text="IGT" Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="EAM_INT_WT" runat="server" CssClass="lables" Checked="True" Text="IPE_Wt" Width="100%"></asp:CheckBox></TD>
						<TD width="13%">
							<asp:CheckBox id="EAM_TOT_WT" runat="server" CssClass="lables" Checked="True" Text="Tot_Wt" Width="100%"></asp:CheckBox></TD>
						<TD width="12%">
							<asp:CheckBox id="EAM_TOTALRANK" runat="server" CssClass="lables" Checked="True" Text="Rank" Width="100%"></asp:CheckBox></TD>
						<TD width="25%">
							<asp:CheckBox id="Checkbox29" runat="server" CssClass="lables" Text="InterTotal" Width="100%"
								Enabled="False"></asp:CheckBox></TD>
					</TR>
				</TABLE></asp:panel><asp:panel id="PnlIPE" runat="server" CssClass="Panels" BackColor="#EBDED6" HorizontalAlign="Center"
				ForeColor="#663300" Font-Bold="True" Visible="False">IPE-RESULT 
      <TABLE width="100%">
					<TR>
						<TD width="25%">
							<asp:CheckBox id="IPE_TOTALMARKS" runat="server" CssClass="lables" Checked="True" Text="Total"
								Width="100%"></asp:CheckBox></TD>
						<TD width="25%">
							<asp:CheckBox id="IPE_IPE_GT" runat="server" CssClass="lables" Checked="True" Text="GrpTot" Width="100%"></asp:CheckBox></TD>
						<TD width="25%">
							<asp:CheckBox id="IPE_GRADE" runat="server" CssClass="lables" Checked="True" Text="Grade" Width="100%"></asp:CheckBox></TD>
						<TD align="right" width="10%">
							<asp:Label id="Label6" runat="server" CssClass="lables">Group</asp:Label></TD>
						<TD width="15%">
							<asp:DropDownList id="IPE_GROUP" runat="server"></asp:DropDownList></TD>
					</TR>
				</TABLE></asp:panel><asp:panel id="PnlOTH" runat="server" CssClass="Panels" BackColor="#EBDED6" HorizontalAlign="Center"
				ForeColor="#663300" Font-Bold="True" Visible="False">OTHER-RESULT 
      <TABLE width="100%">
					<TR>
						<TD width="33%">
							<asp:CheckBox id="OTH_TOTALMARKS" runat="server" CssClass="lables" Checked="True" Text="TotalMark"
								Width="100%"></asp:CheckBox></TD>
						<TD width="33%">
							<asp:CheckBox id="OTH_TOTALRANK" runat="server" CssClass="lables" Checked="True" Text="Rank" Width="100%"></asp:CheckBox></TD>
						<TD width="34%"></TD>
					</TR>
				</TABLE></asp:panel></td>
	</tr>
	<tr>
		<td align="center"><asp:button id="BtnAdd" runat="server" Text="Add"></asp:button></td>
	</tr>
	<TR>
		<TD align="left" width="100%"><asp:label id="LblSelExm" runat="server" CssClass="lables" Width="100%">Selected&nbsp;Exams==></asp:label></TD>
	</TR>
	<TR>
		<TD width="100%">
			<table>
				<tr>
					<td width="25%"><asp:label id="Label15" runat="server" CssClass="Lables" Visible="False" Width="100%">Select Order</asp:label></td>
					<TD width="25%"><asp:dropdownlist id="DrpOrder" runat="server" Visible="False" Width="100%"></asp:dropdownlist></TD>
				</tr>
			</table>
		</TD>
	</TR>
</table>
