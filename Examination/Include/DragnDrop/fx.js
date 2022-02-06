//  Copyright (c) 2012 QuinStreet Inc. All Rights Reserved.
//  prod:51
if (typeof zd_ad_selection_array == 'undefined')
{
        zd_ad_selection_array = {};
}

function zzshuffle(xa)
{
        for (var t10, tmp, i = xa.length; i; rnd = parseInt(Math.random() * i), tmp = xa[--i], xa[i] = xa[rnd], xa[rnd] = tmp);
        return xa;
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

function zzrnd(ii)
{
        return (Math.floor((Math.random() * 10000000000006) % ii));
}

function U9(m0)
{
        if (zzIndexOfList(zzcompete.bannedcamps, m0) < 0)
        {
                zzcompete.chosencamps.push(m0);
        }
        else
        {}
}

function N5(m0)
{
        if (zzIndexOfList(zzcompete.chosencamps, m0) < 0)
        {
                zzcompete.bannedcamps.push(m0);
        }
        else
        {}
}

function F7(g8, v2)
{
        for (var ii = 0; ii < g8.length; ii++)
        {
                m0 = g8[ii];
                if (m0 != v2)
                {
                        if (zzIndexOfList(zzcompete.bannedcamps, m0) < 0)
                        {
                                N5(m0);
                                if (typeof zzcompete.parent2camps[m0] != 'undefined')
                                {
                                        for (var jj = 0; jj < zzcompete.parent2camps[m0].length; jj++)
                                        {
                                                N5(zzcompete.parent2camps[m0][jj]);
                                        }
                                }
                        }
                }
        }
}
var f7;

function U7(v2)
{
        if (f7 < 5)
        {
                f7++;
                U9(v2);
                if (cat != null)
                {
                        F7(zzcompete.cat2camps[cat], v2);
                }
                if (typeof zzcompete.camp2cats[v2] != 'undefined')
                {
                        for (var jj = 0; jj < zzcompete.camp2cats[v2].length; jj++)
                        {
                                cat2 = zzcompete.camp2cats[v2][jj];
                                if (typeof cat2 != 'undefined')
                                {
                                        F7(zzcompete.cat2camps[cat2], v2);
                                }
                        }
                }
                for (var m8 in zzcompete.parent2camps)
                {
                        if (zzIndexOfList(zzcompete.parent2camps[m8], v2) >= 0)
                        {
                                U7(m8);
                        }
                }
        }
        else
        {}
}

function zzcompute_compete_new()
{
        if (typeof zzcompete != 'undefined' && typeof zzcompete.camppriority != 'undefined')
        {
                if (!zzcompete.chosencamps) zzcompete.chosencamps = [];
                if (!zzcompete.chosenads) zzcompete.chosenads = [];
                if (!zzcompete.chosencomp) zzcompete.chosencomp = '';
                zzcompete.bannedcamps = [];
                zzcompete.chosencampstr = '';
                zzcompete.chosenadsstr = '';
                zzcompete.processedcats = [];
                for (var ii = 0; ii < zzcompete.camppriority.length; ii++)
                {
                        var zzshufflecamps = zzshuffle(zzcompete.camppriority[ii]);
                        for (var jj = 0; jj < zzshufflecamps.length; jj++)
                        {
                                var zzcamp = zzshufflecamps[jj];
                                if (zzIndexOfList(zzcompete.bannedcamps, zzcamp) < 0 && zzIndexOfList(zzcompete.chosencamps, zzcamp) < 0)
                                {
                                        f7 = 0;
                                        cat = null;
                                        U7(zzcamp);
                                }
                                else
                                {}
                        }
                }
                if (zzcompete.chosencamps.length > 0)
                {
                        zzcompete.chosencampstr = zzcompete.chosencamps.join("~");
                }
                if (zzcompete.compcamps.length > 0)
                {
                        var d8 = 0;
                        while (!d8)
                        {
                                var rnd = zzrnd(zzcompete.campcount);
                                if (rnd < zzcompete.compcamps.length)
                                {
                                        if (zzIndexOfList(zzcompete.bannedcamps, zzcompete.compcamps[rnd]) < 0)
                                        {
                                                zzcompete.chosencomp = zzcompete.compcamps[rnd];
                                                d8 = 1;
                                        }
                                }
                                else
                                {
                                        break;
                                }
                        }
                        for (var m0 in zzcompete.compcamps)
                        {
                                if (m0 != zzcompete.chosencomp)
                                {
                                        N5(m0);
                                }
                        }
                }
                var t3 = {};
                t3[0] = 99999999;
                for (var m0 in zzcompete.exads)
                {
                        var rnd, tag, last_used_tag;
                        if (zzIndexOfList(zzcompete.bannedcamps, m0) >= 0)
                        {
                                continue;
                        }
                        var rnd = zzrnd(zzcompete.exads[m0].length);
                        var g9 = zzcompete.exads[m0].length;
                        var g7 = -1;
                        tag = last_used_tag = 0;
                        while (g9-- > 0)
                        {
                                var d10 = zzcompete.exads[m0][rnd];
                                tag = d10.replace(/ad[0-9]+/i, '');
                                if ((typeof t3[tag]) == 'undefined')
                                {
                                        last_used_tag = tag;
                                        g7 = rnd;
                                }
                                else if (t3[last_used_tag] > t3[tag])
                                {
                                        last_used_tag = tag;
                                        g7 = rnd;
                                }
                                else
                                {}
                                rnd = (rnd + 1) % zzcompete.exads[m0].length;
                        }
                        if (typeof t3[last_used_tag] == 'undefined')
                        {
                                t3[last_used_tag] = 1;
                        }
                        else
                        {
                                t3[last_used_tag]++;
                        }
                        zzcompete.chosenads.push(zzcompete.exads[m0][g7]);
                }
                if (zzcompete.chosenads.length > 0)
                {
                        zzcompete.chosenadstr = zzcompete.chosenads.join("~");
                }
        }
}
zzcompute_compete_new();