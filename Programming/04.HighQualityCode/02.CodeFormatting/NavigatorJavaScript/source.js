(function () {
    "use strict";

    var b = navigator.appName;
    var addScroll = false;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var xPosition = 0;
    var yPosition = 0;

    document.onmousemove = mouseMove;

    if (b === "Netscape") {
        document.captureEvents(Event.mouseMove);
    }

    function mouseMove(evn) {
        if (b === "Netscape") {
            xPosition = evn.pageX - 5;
            yPosition = evn.pageY;

            if (document.layers['ToolTip'].visibility === 'show') {
                PopTip();
            }
        } else {
            xPosition = event.x - 5;
            yPosition = event.y;

            if (document.all['ToolTip'].style.visibility === 'visible') {
                PopTip();
            }
        }
    }

    function PopTip() {
        if (b === "Netscape") {
            var theLayer = eval('document.layers[\'ToolTip\']');

            if ((xPosition + 120) > window.innerWidth) {
                xPosition = window.innerWidth - 150;
            }

            theLayer.left = xPosition + 10;
            theLayer.top = yPosition + 15;
            theLayer.visibility = 'show';

        } else {
            theLayer = eval('document.all[\'ToolTip\']');
            if (theLayer) {
                xPosition = event.x - 5;
                yPosition = event.y;

                if (addScroll) {
                    xPosition = xPosition + document.body.scrollLeft;
                    yPosition = yPosition + document.body.scrollTop;
                }

                if ((xPosition + 120) > document.body.clientWidth) {
                    xPosition = xPosition - 150;
                }

                theLayer.style.pixelLeft = xPosition + 10;
                theLayer.style.pixelTop = yPosition + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function HideTip() {
        if (b === "Netscape") {
            document.layers['ToolTip'].visibility = 'hide';
        }
        else {
            document.all['ToolTip'].style.visibility = 'hidden';
        }
    }

    function HideMenu() {
        if (b === "Netscape") {
            document.layers['menu1'].visibility = 'hide';
        } else {
            document.all['menu1'].style.visibility = 'hidden';
        }
    }

    function ShowMenu() {
        if (b === "Netscape") {
            theLayer = eval('document.layers[\'menu1\']');
            theLayer.visibility = 'show';
        } else {
            theLayer = eval('document.all[\'menu1\']');
            theLayer.style.visibility = 'visible';
        }
    }
});