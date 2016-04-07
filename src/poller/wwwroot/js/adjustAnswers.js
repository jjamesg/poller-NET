$(function () {

    var numOfAnswers = 4

    var html = buildInputs(numOfAnswers);

    function buildInputs(n) {
        html = ''
        for (var i = 0; i < n; i++) {
            html += '<input name="answers[' + i + ']" class="form-control" style="margin: 8px 0px 8px 0px"/>'
        }
        console.log(html)
        $('.answersIn').html(html);
    }
    
    $('.add').click(function () {
        $('.answersIn').append('<input name="answers[' + numOfAnswers + ']" class="form-control" style="margin: 8px 0px 8px 0px" />')
        numOfAnswers++;
    })
    

});



