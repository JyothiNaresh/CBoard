$(document).ready(function ()
{
        $("#newsletter_signInButton").bind('click', doNLSubmit);
});

function nlsignup()
{
        if (signup_clicked == 1)
        {
                setTimeout('nlsignup()', 20000);
                signup_clicked = 0;
        }
        else if (signup_hovered == 1)
        {
                setTimeout('nlsignup()', 5000);
                signup_hovered = 0;
        }
        else
        {
                document.getElementById('nl-signup').style.display = 'none';
        }
}

function doNLSubmit()
{
        $("#nl-signup-error").hide();
        var email = $("#nl_email").val();
        if (validate(email))
        {
                $("#nl-signup-error").text('* Invalid Email Address');
                $("#nl-signup-error").show();
        }
        else
        {
                var nl_uri = $("#nl_uri").val();
                var NewsletterKey = $("#navNewsletterSignup").val();
                var businessUnit = $("#businessUnit").val();
                var NewsletterSignup = $("#NewsletterSignup").val();
                var RegistrationWebsite = $("#RegistrationWebsite").val();
                $.ajax(
                {
                        type: "POST",
                        url: "/newsletterReg",
                        data: {
                                email: email,
                                uri: nl_uri,
                                NewsletterKey: NewsletterKey,
                                RegistrationWebsite: RegistrationWebsite,
                                businessUnit: businessUnit,
                                NewsletterSignup: NewsletterSignup
                        },
                        dataType: "json",
                        async: false,
                        success: function (data)
                        {
                                if (data.result == "success")
                                {
                                        $("#newsletterform").hide();
                                        $("#newsletter_signInButton").hide();
                                        $("#nl-signup-error").css("color", "#000");
                                        $("#nl-signup-error").text(data.message).show();
                                }
                                else
                                {
                                        $("#nl-signup-error").css("color", "#ff0000");
                                        $("#nl-signup-error").text(data.message).show();
                                }
                        },
                        error: function ()
                        {
                                $("#nl-signup-error").text('Error registering for newsletter.');
                                $("#nl-signup-error").show();
                        }
                });
        }
        return false;
}

function validate(email)
{
        var reg = /^([A-Za-z0-9_\-\.]{2,})+\@([A-Za-z0-9_\-\.]{2,})+\.([A-Za-z]{2,4})$/;
        if (reg.test(email) == false) return true;
        else return false;
}

function readCookie(name)
{
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++)
        {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
}

function welcomeUser()
{
        var firstName = readCookie('FIRST_NAME');
        var lastName = readCookie('LAST_NAME');
        if (firstName != null && lastName != null)
        {
                firstName = decodeURIComponent(firstName);
                lastName = decodeURIComponent(lastName);
                firstName = firstName.replace("+", " ");
                lastName = lastName.replace("+", " ");
                $("#login_register a:first-child").html(firstName + " " + lastName);
                $("#login_register a:first-child").attr("href", "/accountManagement?formType=userProfile");
                $("#login_register a:nth-child(2)").html("Logout");
                $("#login_register a:nth-child(2)").attr("href", "/accountManagement?logout=true&formType=logoutForm");
        }
}
var userId = '';
if (readCookie('USERID_COOKIE') != null)
{
        userId = decodeURIComponent(readCookie('USERID_COOKIE'));
}
else if (readCookie('STAGE_USERID_COOKIE') != null && userId == '')
{
        userId = decodeURIComponent(readCookie('STAGE_USERID_COOKIE'));
}
else if (readCookie('TEST_USERID_COOKIE') != null && userId == '')
{
        userId = decodeURIComponent(readCookie('TEST_USERID_COOKIE'));
}
else if (readCookie('DEV_USERID_COOKIE') != null && userId == '')
{
        userId = decodeURIComponent(readCookie('DEV_USERID_COOKIE'));
}
else userId = 'undefined';
if (userId != 'undefined')
{
        var meta = document.createElement('meta');
        meta.name = 'DCS.dcsaut';
        meta.content = userId;
        document.getElementsByTagName('head')[0].appendChild(meta);
}

function updateIFrame(leadformData)
{
        var iframe = document.getElementById('myframe');
        var containerDiv = document.getElementById('ACL_Form_Container');
        if (typeof (leadformData['height']) != undefined && leadformData['height'] != 0) iframe.setAttribute('height', leadformData['height']);
        welcomeUser();
}

function init()
{
        if (arguments.callee.done) return;
        arguments.callee.done = true;
        if (_timer) clearInterval(_timer);
};
if (document.addEventListener)
{
        document.addEventListener("DOMContentLoaded", init, false);
} /*@cc_on @*/
/*@if (@_win32)
  document.write("<script id=__ie_onload defer src=javascript:void(0)><\/script>");
  var script = document.getElementById("__ie_onload");
  script.onreadystatechange = function() {
    if (this.readyState == "complete") {
      init(); // call the onload handler
    }
  };
/*@end @*/
if (/WebKit/i.test(navigator.userAgent))
{
        var _timer = setInterval(function ()
        {
                if (/loaded|complete/.test(document.readyState))
                {
                        init();
                }
        }, 10);
}
window.onload = welcomeUser;