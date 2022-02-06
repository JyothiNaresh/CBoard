//  Copyright (c) 2012 QuinStreet Inc. All Rights Reserved.
//  prod:51
function N2()
{
        zzPage_obj.zzGeo = zzPage_obj['cookies']['qsg'];
        zzPage_obj.zzCountry = parseInt(U2(zzPage_obj.zzGeo));
        zzPage_obj.zzState = parseInt(N3(zzPage_obj.zzGeo));
        zzPage_obj.zzMetro = parseInt(F3(zzPage_obj.zzGeo));
        zzPage_obj.zzFlash = (zzPage_obj['cookies']['QUADIDX'] & 0x8);
        zzPage_obj.zzFlashVersion = 4 + ((zzPage_obj['cookies']['QUADIDX'] & 0x70) >> 4);
        zzPage_obj.zzUserAgent = navigator.userAgent.toLowerCase();
        zzPage_obj.zzIsMac = (zzPage_obj.zzUserAgent.indexOf('mac') != -1);
        zzPage_obj.zzIsOpera = (zzPage_obj.zzUserAgent.indexOf('opera') != -1);
        zzPage_obj.zd_inject_params = N8();
}

function F10()
{
        if (zzPage_obj['cookies']['QIDA'].indexOf('OPT_OUT') == -1)
        {
                if ((zzPage_obj['cookies']['qsg'] == 254) || (!('qsgr' in zzPage_obj['cookies'])))
                {
                        N0('qsgr', '1', 2592000000);
                        if (typeof zz_in_ihtml != 'undefined')
                        {
                                var d9 = F0('g', false);
                                N0('qsg', d9, 2592000000);
                                zzPage_obj['cookies']['qsg'] = d9;
                        }
                        else
                        {
                                document.write("<SC" + "RIPT LANGUAGE='JavaScript' SRC='http://o1.qnsr.com/init/" + Math.random() + "/g.js'><\/SCR" + "IPT>");
                        }
                }
                if (zzPage_obj['cookies']['QUADIDX'] == 0 || (!('qidxr' in zzPage_obj['cookies'])))
                {
                        N0('qidxr', '1', 2592000000);
                        if (typeof zz_in_ihtml != 'undefined')
                        {
                                var i6 = F0('x', false);
                                N0('QUADIDX', i6, 2592000000);
                                zzPage_obj['cookies']['QUADIDX'] = i6;
                                zzPage_obj.d0 = i6;
                        }
                        else
                        {
                                if (document.all && !zzPage_obj.zzIsMac && !zzPage_obj.zzIsOpera)
                                {
                                        zzPage_obj.d0 = U3();
                                }
                                else
                                {
                                        zzPage_obj.d0 = F4();
                                }
                                N0('QUADIDX', zzPage_obj.d0, 2592000000);
                                zzPage_obj['cookies']['QUADIDX'] = zzPage_obj.d0;
                        }
                }
        }
}

function U1()
{
        var i0 = document.cookie;
        var m1 = new Array();
        var g2 = new Array();
        zzPage_obj['cookies'] = new Array();
        if (!('qsg' in zzPage_obj['cookies']))
        {
                zzPage_obj['cookies']['qsg'] = 254;
        }
        if (!('QUADIDX' in zzPage_obj['cookies']))
        {
                zzPage_obj['cookies']['QUADIDX'] = 0;
        }
        if (!('QIDA' in zzPage_obj['cookies']))
        {
                zzPage_obj['cookies']['QIDA'] = "";
        }
        m1 = i0.split(';');
        var t9 = (m1 != null) ? m1.length : 0;
        for (var i = 0; i < t9; i++)
        {
                m1[i] = m1[i].replace(/^\s/, '');
                g2 = m1[i].split('=');
                if (g2 && g2.length == 2)
                {
                        zzPage_obj['cookies'][g2[0]] = g2[1];
                }
        }
}

function N6(f2, t6)
{
        if (t6)
        {
                U1();
        }
        if (f2 in zzPage_obj['cookies'])
        {
                return zzPage_obj['cookies'][f2];
        }
        else
        {
                return '';
        }
}

function N0(b1, f5, i3)
{
        if (document.cookie.indexOf('OPT_OUT') == -1)
        {
                var k3 = new Date();
                var k0;
                if (typeof i3 == 'undefined' || i3 == -1)
                {
                        k0 = "Thu,01-Jan-1970 00:00:01 GMT";
                }
                else
                {
                        k3.setTime(k3.getTime() + i3);
                        k0 = k3.toGMTString();
                }
                document.cookie = b1 + '=' + f5 + ';expires=' + k0 + ';path=/;';
                zzPage_obj['cookies'][b1] = f5;
        }
}

function zzChkFCapCookie(y5, m3, b1)
{
        var g0;
        var i0 = N6(b1, true);
        var i;
        var v0;
        var t1 = 0;
        var f1 = new Date();
        if (i0 != "")
        {
                g0 = i0.split(":");
                for (i = 0; i < g0.length; i++)
                {
                        v0 = g0[i].split(",");
                        if (v0[0] == y5)
                        {
                                t1 = 1;
                                if ((f1.valueOf() > v0[2]) || (m3 > v0[1]))
                                {
                                        return 1;
                                }
                                else
                                {
                                        return -1;
                                }
                        }
                }
        }
        else
        {
                document.cookie = 'cookies=1;path=/;';
                return (document.cookie == '') ? -1 : 0;
        }
        if (!t1)
        {
                return 0
        }
}

function zzSetFCapCookie(r5, v5, m5, m3, b1)
{
        var f1 = new Date();
        var i0;
        var g0;
        var t1 = 0;
        var i1 = 0;
        var d3 = 1000 * 60 * 60 * 24 * m5;
        var k0 = new Date(f1.valueOf() + d3);
        var i;
        var i2 = "";
        var v0;
        var t0;
        v0 = r5 + "" + v5;
        var d2 = 0;
        i0 = N6(b1, true);
        var v8 = F6(i0);
        if (i0 != v8)
        {
                i0 = v8;
                d2 = 1;
        }
        if (i0 != "")
        {
                g0 = i0.split(":");
                for (i = 0; i < g0.length; i++)
                {
                        if (g0[i] != "")
                        {
                                t0 = g0[i].split(",");
                                if (t0[0] == v0)
                                {
                                        t1 = 1;
                                        i2 += v0 + "," + (parseInt(t0[1]) + 1) + "," + k0.valueOf() + ":";
                                        d2 = 1;
                                }
                                else
                                {
                                        i2 += g0[i] + ":";
                                }
                        }
                }
                i1 = F8(i0);
        }
        if (!t1)
        {
                i2 += v0 + ",1," + k0.valueOf() + ":";
                d2 = 1;
        }
        if (i1 < k0.valueOf())
        {
                d3 = k0.valueOf() - f1.valueOf();
        }
        if (d2)
        {
                N0(b1, i2, d3);
        }
}

function F6(r2)
{
        var g0;
        var i;
        var t0;
        var f1 = new Date();
        var i0 = "";
        if (r2 != "")
        {
                g0 = r2.split(":");
                for (i = 0; i < g0.length; i++)
                {
                        t0 = g0[i].split(",");
                        if (t0[2] >= f1.valueOf())
                        {
                                i0 += g0[i] + ":";
                        }
                }
        }
        return i0;
}

function F8(r2)
{
        var g0;
        var i;
        var t0;
        var i1 = 0;
        g0 = r2.split(":");
        for (i = 0; i < g0.length; i++)
        {
                t0 = g0[i].split(";");
                if (t0[3] > i1)
                {
                        i1 = t0[2];
                }
        }
        return i1;
}

function U4(r6)
{
        var t2 = r6.toString().match(/function\s+(\w*)/)[1];
        if ((t2 == null) || (t2.length == 0))
        {
                return "anonymous();";
        }
        else
        {
                return t2 + "();";
        }
}

function N4()
{
        var k5 = "";
        for (var a = arguments.caller; a != null; a = a.caller)
        {
                k5 += U4(a.callee);
                if (a.caller == a) break;
        }
        return k5;
}

function F2()
{
        var d1 = "";
        var t2 = "anonymous();";
        var v4 = 0;
        window.onerror = null;
        for (var i = 0; i < arguments.length; i++)
        {
                d1 += 'a' + i + '=' + arguments[i] + ';';
                if (i == 2)
                {
                        v4 = escape(arguments[i]);
                }
        }
        d1 = N4() + d1;
        if (navigator.cookieEnabled)
        {
                d1 = d1 + 'c=' + navigator.cookieEnabled + ';';
        }
        d1 = d1 + "C=" + document.cookie + ";";
        if (document.cookie.indexOf('QUADERROR') == -1)
        {
                var zzQTobj = new Object();
                N0('QUADERROR', v4, 259200000, zzQTobj);
                var v6 = new Image();
                v6.src = 'http://l1.cdn.qnsr.com/log/ERR.gif?v=./ar/lite/e1/v51/;' + d1 + 'b=' + navigator.userAgent + ';' + Math.random();
        }
        return true;
}

function U2(y1)
{
        return y1 & 255;
}

function F3(y1)
{
        return (y1 >> 14) & 1023;
}

function N3(y1)
{
        return (y1 >> 8) & 63;
}

function zzIndexOfList(ll, obj)
{
        for (var i = 0; i < ll.length; i++)
        {
                if (ll[i] == obj)
                {
                        return i;
                }
        }
        return -1;
}

function U3()
{
        var d0 = 1;
        zzPage_obj.y3 = 0;
        document.writeln('<SCR' + 'IPT LANGUAGE="VBS' + 'cript">');
        document.writeln('on error resume next\n');
        document.writeln('For i=4 to 11');
        document.writeln('If Not(IsObject(CreateObject("ShockwaveFlash.ShockwaveFlash." & i)))Then');
        document.writeln('Else');
        document.writeln('zzPage_obj.y3=i');
        document.writeln('End If');
        document.writeln('Next');
        document.writeln('</scr' + 'ipt>');
        if (navigator.javaEnabled())
        {
                d0 |= 2;
        }
        if (zzPage_obj.y3 >= 4)
        {
                d0 |= ((zzPage_obj.y3 - 4) << 4);
                d0 |= 8;
        }
        return d0;
}

function F4()
{
        var y3 = 0;
        var d0 = 1;
        if (navigator.mimeTypes && navigator.mimeTypes["application/x-shockwave-flash"] && navigator.mimeTypes["application/x-shockwave-flash"].enabledPlugin)
        {
                if (navigator.plugins && navigator.plugins["Shockwave Flash"])
                {
                        var k7 = navigator.plugins["Shockwave Flash"].description;
                        try
                        {
                                y3 = k7.match(/(\d+)\./)[1];
                        }
                        catch (e1)
                        {}
                }
        }
        if (navigator.javaEnabled())
        {
                d0 |= 2;
        }
        if (y3 >= 4)
        {
                d0 |= ((y3 - 4) << 4);
                d0 |= 8;
        }
        return d0;
}
var y0 = '';

function zzrnd(ii)
{
        return (Math.floor((Math.random() * 10000000000006) % ii));
}

function F1(y0)
{
        var r3 = '';
        var g10 = '';
        var g3 = '';
        var m2 = y0.split(':');
        zzChosenCamps = '';
        zzChosenComp = '';
        zzChosenAds = '';
        zzRndCamp = 0;
        if (m2.length == 3)
        {
                g3 = m2[0];
                if (g3 != '')
                {
                        zzChosenCamps = g3.split('~');
                        zzRndCamp = parseInt(Math.random() * zzChosenCamps.length);
                }
                zzChosenComp = m2[1];
                r3 = m2[2];
                if (r3 != '')
                {
                        zzChosenAds = r3.split('~');
                }
        }
}
var b7 = new Array();
var d6 = 0;
var y6 = 0;

function F0(f2, y9)
{
        if (d6 < 1 || y9)
        {
                var b4 = '' + window.location.search;
                var v3 = new Array();
                var k10 = '';
                var v10 = '';
                b4 = b4.replace(/^\?/, '');
                if (f2 == 'l')
                {
                        var k8 = "";
                        y6 = b4.indexOf(";l=http");
                        if (y6 != -1)
                        {
                                k8 = b4.substring(y6 + 3, b4.length);
                                d6 = 0;
                        }
                        return k8;
                }
                else
                {
                        v3 = b4.split(';');
                        d6 = v3.length;
                        for (var i = 0; i < d6; i++)
                        {
                                if (v3[i].length > 2)
                                {
                                        k10 = v3[i].split('=');
                                        b7[v3[i].substring(0, 1)] = v3[i].substring(2, v3[i].length);
                                }
                        }
                }
        }
        if (b7[f2])
        {
                return b7[f2];
        }
        else
        {
                return '';
        }
}

function N8()
{
        var b3;
        var i7 = '';
        if (document.all)
        {
                b3 = document.all.tags('meta');
        }
        else if (document.documentElement)
        {
                b3 = document.getElementsByTagName('meta');
        }
        if (typeof (b3) != 'undefined')
        {
                var f9 = b3.length;
                var k6 = 0;
                for (var i = 0; i < f9; i++)
                {
                        var b6 = b3.item(i).name;
                        if ((b6.length > 0) && (b6.match(/^inject_params/)))
                        {
                                i7 += ';' + b3.item(i).content.replace(/&/g, ';');
                                k6++;
                        }
                        if ((b6.length > 0) && (b6.match(/^qs.quad.keywords/)) && (b3.item(i).content.length > 0))
                        {
                                i7 += ';h=' + eval('(' + b3.item(i).content + ')').nodes + ';';
                                k6++;
                        }
                        if (k6 == 2)
                        {
                                break;
                        }
                }
        }
        return i7;
}
var zzBrowserDetect = {
        init: function ()
        {
                if (!this.alreadyLookedup)
                {
                        this.zzbrowser = this.searchString(this.dataBrowser) || "An unknown browser";
                        this.zzversion = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "an unknown version";
                        var str = '' + this.zzversion;
                        this.zzbrowser = this.zzbrowser + " " + str.replace(/(\d*).*/, '$1.x');
                        this.zzOS = this.searchString(this.dataOS) || "an unknown OS";
                        this.alreadyLookedup = 1;
                }
        },
        searchString: function (data)
        {
                for (var i = 0; i < data.length; i++)
                {
                        var r4 = data[i].string;
                        var v9 = data[i].prop;
                        this.versionSearchString = data[i].versionSearch || data[i].identity;
                        if (r4)
                        {
                                if (r4.indexOf(data[i].subString) != -1) return data[i].identity;
                        }
                        else if (v9) return data[i].identity;
                }
        },
        searchVersion: function (r4)
        {
                var i8 = r4.indexOf(this.versionSearchString);
                if (i8 == -1) return;
                return parseFloat(r4.substring(i8 + this.versionSearchString.length + 1));
        },
        dataBrowser: [
        {
                string: navigator.userAgent,
                subString: "Chrome",
                identity: "Chrome"
        },
        {
                string: navigator.userAgent,
                subString: "OmniWeb",
                versionSearch: "OmniWeb/",
                identity: "OmniWeb"
        },
        {
                string: navigator.vendor,
                subString: "Apple",
                identity: "Safari",
                versionSearch: "Version"
        },
        {
                prop: window.opera,
                identity: "Opera"
        },
        {
                string: navigator.vendor,
                subString: "iCab",
                identity: "iCab"
        },
        {
                string: navigator.vendor,
                subString: "KDE",
                identity: "Konqueror"
        },
        {
                string: navigator.userAgent,
                subString: "KONQUEROR",
                identity: "Konqueror"
        },
        {
                string: navigator.userAgent,
                subString: "AOLBROWSER",
                identity: "AOL"
        },
        {
                string: navigator.userAgent,
                subString: "WEBTV",
                identity: "WebTV"
        },
        {
                string: navigator.userAgent,
                subString: "Firefox",
                identity: "Firefox"
        },
        {
                string: navigator.vendor,
                subString: "Camino",
                identity: "Camino"
        },
        {
                string: navigator.userAgent,
                subString: "Netscape",
                identity: "Netscape"
        },
        {
                string: navigator.userAgent,
                subString: "MSIE",
                identity: "MS Explorer",
                versionSearch: "MSIE"
        },
        {
                string: navigator.userAgent,
                subString: "MICROSOFT INTERNET EXPLORER",
                identity: "MS Explorer"
        },
        {
                string: navigator.userAgent,
                subString: "Gecko",
                identity: "Mozilla",
                versionSearch: "rv"
        },
        {
                string: navigator.userAgent,
                subString: "Mozilla",
                identity: "Netscape",
                versionSearch: "Mozilla"
        },
        {
                string: navigator.userAgent,
                subString: "Lynx",
                identity: "Text-only"
        },
        {
                string: navigator.userAgent,
                subString: "ELinks",
                identity: "Text-only"
        },
        {
                string: navigator.userAgent,
                subString: "galeon",
                identity: "Galeon"
        }],
        dataOS: [
        {
                string: navigator.userAgent,
                subString: "Windows NT 6.0",
                identity: "Windows Vista"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_XP",
                identity: "Windows XP"
        },
        {
                string: navigator.userAgent,
                subString: "Windows NT 5.1",
                identity: "Windows XP"
        },
        {
                string: navigator.platform,
                subString: "Mac",
                identity: "Macintosh"
        },
        {
                string: navigator.userAgent,
                subString: "iPhone",
                identity: "iPhone/iPod/iPad"
        },
        {
                string: navigator.userAgent,
                subString: "iPod",
                identity: "iPhone/iPod/iPad"
        },
        {
                string: navigator.userAgent,
                subString: "iPad",
                identity: "iPhone/iPod/iPad"
        },
        {
                string: navigator.userAgent,
                subString: "BlackBerry",
                identity: "BlackBerry"
        },
        {
                string: navigator.userAgent,
                subString: "Android",
                identity: "Android"
        },
        {
                string: navigator.userAgent,
                subString: "Palm",
                identity: "Palm"
        },
        {
                string: navigator.userAgent,
                subString: "AMIGA-AWEB",
                identity: "Amiga"
        },
        {
                string: navigator.userAgent,
                subString: "HP-UX",
                identity: "Unix"
        },
        {
                string: navigator.userAgent,
                subString: "LINUX",
                identity: "Unix"
        },
        {
                string: navigator.userAgent,
                subString: "Windows NT 5.0",
                identity: "Windows 2000"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_NT 5.0",
                identity: "Windows 2000"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_2000",
                identity: "Windows 2000"
        },
        {
                string: navigator.userAgent,
                subString: "Windows ME",
                identity: "Windows ME"
        },
        {
                string: navigator.userAgent,
                subString: "WIN 9X",
                identity: "Windows ME"
        },
        {
                string: navigator.userAgent,
                subString: "WIN95",
                identity: "Windows 95"
        },
        {
                string: navigator.userAgent,
                subString: "Windows 95",
                identity: "Windows 95"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_95",
                identity: "Windows 95"
        },
        {
                string: navigator.userAgent,
                subString: "WIN98",
                identity: "Windows 98"
        },
        {
                string: navigator.userAgent,
                subString: "Windows 98",
                identity: "Windows 98"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_98",
                identity: "Windows 98"
        },
        {
                string: navigator.userAgent,
                subString: "WINNT",
                identity: "Windows NT"
        },
        {
                string: navigator.userAgent,
                subString: "Windows NT",
                identity: "Windows NT"
        },
        {
                string: navigator.userAgent,
                subString: "Windows_NT",
                identity: "Windows NT"
        }]
};

function U10(zzQTobj)
{
        if ((!zzQTobj.r1) && (zzQTobj.zzTrd != ''))
        {
                zzQTobj.zzTrd = ';l=' + zzQTobj.zzTrd;
        }
        zzQTobj.f0 = zzPage_obj.zd_inject_params + zzQTobj.f0;
        if (zzQTobj.f0 != '')
        {
                zzQTobj.zzParam = zzQTobj.f0.replace(/&/g, ';');
                if (!zzQTobj.r1)
                {
                        zzQTobj.f0 = ';p=' + escape(zzQTobj.zzParam);
                }
                else
                {
                        zzQTobj.f0 = '&p=' + escape(zzQTobj.zzParam);
                }
        }
        if (typeof f8 != 'undefined' && document.referrer)
        {
                zzQTobj.zzRef = document.referrer;
        }
        else
        {
                zzQTobj.zzRef = document.URL;
        }
        zzQTobj.zzRef = zzQTobj.zzRef.replace(/;/g, 'QQQQ');
        zzQTobj.zzRef = zzQTobj.zzRef.replace(/[&#].*/, '');
        zzQTobj.zzStr = zzQTobj.zzStr + 'e=i;s=' + zzQTobj.zzSection + ';g=' + zzPage_obj.zzCountry + ';w=' + zzPage_obj.zzState + ';m=' + zzPage_obj.zzMetro + ';' + ';z=' + zzrnd(1000000000);
        zzQTobj.v1 = zzQTobj.zz_size * 256;
        y0 = ';d=::';
        if (typeof zzcompete != 'undefined')
        {
                F1(zzcompete.chosencampstr + ':' + zzcompete.chosencomp + ':' + zzcompete.chosenadstr);
                y0 = ';d=' + zzcompete.chosencampstr + ':' + zzcompete.chosencomp + ':' + zzcompete.chosenadstr;
        }
}

function F5(y10)
{
        if (!('qsmo' in zzPage_obj['cookies']))
        {
                zzPage_obj['cookies']['qsmo'] = 1;
                var f10 = new Image();
                f10.src = 'http://e1.cdn.qnsr.com/p/p.gif?' + Math.random();
                document.cookie = "qsmo=1";
        }
}

function N10(zzQTobj)
{
        U10(zzQTobj);
        if (document.layers)
        {
                zzQTobj.b0 = 'n=' + zzQTobj.k1 + ';c=' + zzQTobj.zz_cat + ';s=' + zzQTobj.g1 + ';x=' + zzQTobj.v1 + ';u=j;z=' + zzrnd(1000000000) + ';'
                document.write("<span id='qsjs' onmouseover=F5('qsjs')><a href='http://o1.qnsr.com/cgi/r?" + zzQTobj.b0 + zzQTobj.f0 + ";y=" + zzRef + zzTrd + "'><img border='0' width='" + zzQTobj.zz_width + "' height='" + zzQTobj.zz_height + "' src='http://o1.qnsr.com/cgi/x?" + zzQTobj.b0 + "'></a></span>");
        }
        else
        {
                zzQTobj.v1 += 1;
                if (zzQTobj.r1 == 1)
                {
                        zzQTobj.b0 = 'http://e1.cdn.qnsr.com/cgi/d/' + zzQTobj.v1 + '/0/' + zzQTobj.k1 + '/' + zzQTobj.zz_cat + '/i0.js?' + ';z=' + zzrnd(1000000000);
                        document.write('<span id="qsjs" onmouseover=F5("qsjs")><scr' + 'ipt language="JavaScript" src="' + zzQTobj.b0 + '"><\/sc' + 'ript></span>');
                }
                else
                {
                        zzQTobj.b0 = 'http://e1.cdn.qnsr.com/cgi/d/' + zzQTobj.v1 + '/0/' + zzQTobj.k1 + '/' + zzQTobj.zz_cat + '/i0.html?' + zzQTobj.f0 + ';s=' + zzQTobj.g1 + ';g=' + zzPage_obj.zzGeo + ';x=' + zzPage_obj['cookies']['QUADIDX'] + ';y=' + zzQTobj.zzRef + y0 + ';z=' + zzrnd(1000000000) + ';' + zzQTobj.zzTrd;
                        document.write("<span id='qsif' onmouseover=F5('qsif')><iframe src='" + zzQTobj.b0 + "' frameborder=0 marginheight=0 marginwidth=0 scrolling='no' allowTransparency='true' width=" + zzQTobj.zz_width + " height=" + zzQTobj.zz_height + "></iframe></span>");
                }
        }
}

function U6(zzQTobj)
{
        zzQTobj.zz_cat = 0;
        zzQTobj.zz_height = 0;
        zzQTobj.v1 = 0;
        zzQTobj.k1 = 0;
        zzQTobj.f0 = '';
        zzQTobj.g1 = 0;
        zzQTobj.zz_size = 0;
        zzQTobj.zz_width = 0;
        zzQTobj.zzChosenAds = '';
        zzQTobj.zzChosenCamps = '';
        zzQTobj.zzChosenComp = '';
        zzQTobj.zzD = window.document;
        zzQTobj.zzParam = '';
        zzQTobj.zzRef = '';
        zzQTobj.zzRndCamp = 0;
        zzQTobj.zzSection = zzQTobj.g1;
        zzQTobj.zzStr = '';
        zzQTobj.zzTrd = '';
}

function zzfocrender(g5, y4, t4, t5, zz_width, zz_height, f0, g4, r8)
{
        zzflcrender(g5, y4, t4, t5, zz_width, zz_height, f0, g4, r8, 1);
}

function zzflcrender(g5, y4, t4, t5, zz_width, zz_height, f0, g4, r8, r1)
{
        var zzQTobj = new Object();
        U6(zzQTobj);
        if (!zzPage_obj.zzIsMac)
        {
                zzPage_obj['zz_old_error_handler'] = window.onerror;
                window.onerror = F2;
        }
        if (typeof g5 != 'undefined') zzQTobj.k1 = g5;
        if (typeof y4 != 'undefined')
        {
                zzQTobj.g1 = y4;
                zzQTobj.zzSection = y4;
        }
        if (typeof t4 != 'undefined') zzQTobj.zz_cat = t4;
        if (typeof t5 != 'undefined') zzQTobj.zz_size = t5;
        if (typeof zz_height != 'undefined') zzQTobj.zz_height = zz_height;
        if (typeof zz_width != 'undefined') zzQTobj.zz_width = zz_width;
        if (typeof f0 != 'undefined') zzQTobj.f0 = f0;
        if (typeof g4 != 'undefined')
        {
                zzQTobj.zflag_trd = g4;
                zzQTobj.zzTrd = g4;
        }
        if (typeof r1 != 'undefined') zzQTobj.r1 = r1;
        U1();
        N2();
        zzQTobj.zzGeo = zzPage_obj.zzGeo;
        zzQTobj.zzCountry = zzPage_obj.zzCountry
        zzQTobj.zzState = zzPage_obj.zzState;
        zzQTobj.zzMetro = zzPage_obj.zzMetro
        zzQTobj.zzFlash = zzPage_obj.zzFlash
        zzQTobj.zzFlashVersion = zzPage_obj.zzFlashVersion
        var m7 = parseInt(t4.replace(/\/.*/, ''));
        m7 = ((parseInt(g5) * 1000000) + m7);
        zzPage_obj[m7] = zzQTobj;
        N10(zzQTobj);
        if (!zzPage_obj.zzIsMac)
        {
                window.onerror = zzPage_obj['zz_old_error_handler'];
        }
}
if (typeof zzPage_obj == 'undefined')
{
        var zzPage_obj = new Object();
        zzPage_obj.zz_old_error_handler = window.onerror;
        U1();
        N2();
        F10();
}
if (typeof zd_ad_selection_array == 'undefined')
{
        zd_ad_selection_array = {};
}

function zzGetTaxNode(obj)
{
        var d5 = zd_ad_selection_array[obj];
        if (typeof d5 == 'undefined')
        {
                return 0;
        }
        return d5;
}

function zzChkTaxAds(k4, f4)
{
        if (typeof txnodes != 'undefined')
        {
                var f3 = document.getElementsByName("qs.quad.keywords");
                var i4 = "0";
                if (f3.length > 0 && f3[0].content.length > 0)
                {
                        i4 = "tx" + eval("(" + f3[0].content + ")").nodes.split(",")[0];
                }
                for (var zzprtxlvl in txnodes)
                {
                        for (var zzprtxnode in txnodes[zzprtxlvl])
                        {
                                if (zzprtxnode == i4)
                                {
                                        for (var i = 0; i < txnodes[zzprtxlvl][zzprtxnode].length; i++)
                                        {
                                                if (k4 == txnodes[zzprtxlvl][zzprtxnode][i])
                                                {
                                                        f4.tx = zzprtxnode.replace('tx', '');
                                                        return 0;
                                                }
                                        }
                                }
                        }
                }
                for (var zztxlvl in txnodes)
                {
                        for (var zztxnode in txnodes[zztxlvl])
                        {
                                for (var i = 0; i < txnodes[zztxlvl][zztxnode].length; i++)
                                {
                                        if (k4 == txnodes[zztxlvl][zztxnode][i])
                                        {
                                                f4.tx = zztxnode.replace('tx', '');
                                                return Number(zztxlvl);
                                        }
                                }
                        }
                }
        }
        return 1000;
}