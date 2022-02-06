Module ErrorMessages

    Public Function DataBaseErrorMessage(ByVal Str As String) As String
        Dim errMessage = ""

        Select Case Str.Substring(0, 9)
            Case "ORA-00001"
                errMessage = "SQl:Record Already Exists With This Name"
                Exit Select
            Case "ORA-01422"
                errMessage = "SQl:Fetch returns more than one row"
                Exit Select
            Case "ORA-02292"
                errMessage = "SQl:Child Record Found"
                Exit Select
            Case "ORA-06550"
                errMessage = "SQl:Invalid Object (i.e Table,Procedure,Parameters)"
                Exit Select
            Case "ORA-00903"
                errMessage = "SQl:Invalid Table Name"
                Exit Select
            Case "ORA-00904"
                errMessage = "SQl:Invalid Identifier"
                Exit Select
            Case "ORA-00933"
                errMessage = "SQl: Command Not Properly Ended"
                Exit Select
            Case "ORA-06502"
                errMessage = "SQl:Character to number conversion error"
                Exit Select
            Case "OCI-22060"
                errMessage = "SQl:Invalid argument or uninitialized number"
                Exit Select
            Case "ORA-24338"
                errMessage = "SQl: Statement not executed"
                Exit Select
            Case "ORA-01438"
                errMessage = "SQl: Value larger than specified precision"
                Exit Select
            Case "ORA-06512"
                errMessage = "SQl: Value larger than specified precision"
                Exit Select
            Case "ORA-20101"
                errMessage = "SQl: Not enough leaves available"
                Exit Select
            Case "ORA-20102"
                errMessage = "SQl: Dates difference should not more than one month"
                Exit Select
            Case "ORA-20103"
                errMessage = "SQl: No data found in Definition table"
                Exit Select
            Case "ORA-20104"
                errMessage = "SQl: No data found in Employee Leave table"
                Exit Select
            Case "ORA-20105"
                errMessage = "SQl: Employee does not exist"
                Exit Select
            Case "ORA-02291"
                errMessage = "SQl: Integrity Constraint, Parent Key Not Found"
                Exit Select
            Case "ORA-00923"
                errMessage = "SQl: FROM Keyword Not found Where expected"
                Exit Select
            Case "ORA-01036"
                errMessage = " SQl: Illegal Variable Name/Number "
                Exit Select
            Case "ORA-01400"
                errMessage = " SQl: Cannot Insert NULL "
                Exit Select
            Case "ORA-00979"
                errMessage = " Not A Group By Expression "
                Exit Select
            Case "ORA-00907"
                errMessage = " To Increase the SqlString Size In Middle Layer "
                Exit Select
            Case "ORA-01722"
                errMessage = " SQl:Invalid Number "
                Exit Select
            Case "ORA-00942"
                errMessage = " SQl:Table or View Does Not Exist "
                Exit Select
            Case "ORA-01033"
                errMessage = " SQl:Data Base Shut Down Due To Maintains "
                Exit Select
            Case Else
                errMessage = "SQl:New Error Add In Error Class"
                Exit Select
        End Select
   
      
        Return errMessage

    End Function

    Public Function GeneralErrorMessage(ByVal Str As String) As String

        Dim errMessage As String

        Select Case Str
            Case "Thread was being aborted."
                errMessage = ""
            Case Else
                errMessage = Str
        End Select

        Return errMessage

    End Function

End Module

