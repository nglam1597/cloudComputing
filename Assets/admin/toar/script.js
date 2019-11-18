$(function () {

    function Toast(type, css, msg) {
        this.type = type;
        this.css = css;
        this.msg = msg;
    }

    var toasts = [
        new Toast('success', 'toast-top-center ', 'Tạo Lịch Thi Đấu Thành Công'),

    ];

    toastr.options.positionClass = 'toast-top-full-width';
    toastr.options.extendedTimeOut = 1000; //1000;
    toastr.options.timeOut = 1000;
    toastr.options.fadeOut = 250;
    toastr.options.fadeIn = 250;

    var i = 0;

    $('#tryMe').click(function () {
        $('#tryMe').prop('disabled', true);

        delayToasts();
        
    });


    function delayToasts() {
        if (i === toasts.length) { return; }
        var delay = i === 0 ? 0 : 2100;
        window.setTimeout(function () { showToast(); }, delay);

        // re-enable the button        
        if (i === toasts.length - 1) {
            window.setTimeout(function () {
                $('#tryMe').prop('disabled', false);
                i = 0;
            }, delay + 3000);
        }
    }

    function showToast() {
        var t = toasts[i];
        toastr.options.positionClass = t.css;
       
        toastr[t.type](t.msg);
        i++;
        delayToasts();
    }


    
})
