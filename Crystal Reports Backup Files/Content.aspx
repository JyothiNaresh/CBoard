<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Content.aspx.vb" Inherits="CollegeBoard.Content" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>NIMS - Narayana Information Management System</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language=javascript src=../Include/windowstatus.js></script>
	</HEAD>
	<frameset ID="outer" rows="47,*,20" cols="*" frameborder="NO" border="0" framespacing="0">
		<frame src="Header.aspx" name="headerFrame" noresize scrolling="no">
		<frameset id="inner" cols="215,*" framespacing="0" frameborder="NO" border="0">
			<frame name="left" scrolling="yes" src="../Security/UserTree.aspx">
			<frame name="right" src="../NoticeBoard/NoticeDisplay.aspx">
		</frameset>
		<frame src="footer.htm" name="bottomFrame" noresize scrolling="no">
	</frameset>
</HTML>
