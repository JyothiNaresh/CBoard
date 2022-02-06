function HideCtrl(ctrl, timer) {
    var ctry_array = ctrl.split(",");
    var num = 0, arr_length = ctry_array.length;
    while (num < arr_length) {
        if (document.getElementById(ctry_array[num])) {
            setTimeout('document.getElementById("' + ctry_array[num] + '").style.display = "none";', timer);
        }s
        num += 1;
    }
    return false;
}