var myChart = null;

window.setup = (id, config) => {
    var canvas = document.getElementById(id)
    var ctx = canvas.getContext('2d');

    var chart = Chart.getChart(id);

    if (chart) {
        chart.clear();
        chart.destroy();
    }


    myChart = new Chart(ctx, config);
}