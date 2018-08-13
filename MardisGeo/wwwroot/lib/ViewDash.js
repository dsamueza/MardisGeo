function GetDashbord(data) {
    var url;
    var urlMobil;
    $.ajax({
        url: "/Map/GetDashBord",
        type: "Post",
        async: false,
        data: {
            iddash: data
        },
        success: function (_model) {

            url = _model[0].geo_dashboard_link;
            urlMobil = _model[0].geo_dashboard_link_mobil;

        },
        error: function (e) {
            console.log(e)
        }
    });


    initViz1(url, urlMobil);
}



var viz;

function initViz1(dashboard, dashboardMobil) {
    var win = '1250px';
    var hi = '900px'
    var porcentaje = 0;
    if (screen.width < 770) {
        porcentaje = 1
        dashboard = dashboardMobil;
    }
    if (screen.width > 760) {
        porcentaje = 8.5

    }
    if (screen.width > 1200) {
        porcentaje = 6

    }
    if (screen.width > 1800) {
        porcentaje = 4.5

    }
    var res = (screen.width * porcentaje) / 100
    var tam = screen.width - res
    win = tam + 'px'
    var containerDiv = document.getElementById("vizContainer"),
        url = dashboard,
        options = {
            hideTabs: true,
            width: win,
            height: hi
        };

    if (viz) {
        viz.dispose();
    }
    viz = new tableau.Viz(containerDiv, url, options);
    // Create a viz object and embed it in the container div.
}