$(document).ready(function () {

    $('.button-action-edit').click(function (e) {
        var clickedButton = $(e.target);
        var parentBlock = clickedButton.parents('.parent-tweet-container');
        var tweetId = $(this).parents('.parent-tweet-container').attr('id');
        var currentText = $(parentBlock).find('.tweet-text').text();

        $(parentBlock).find('textarea').show().val(currentText).focus();
        $(parentBlock).find('.tweet-text').hide();
        $(parentBlock).find('.buttons-edit-delete').hide();
        $(parentBlock).find('.buttons-save-cancel').show();
    });

    $('.button-action-cancel').click(function (e) {
        var clickedButton = $(e.target);
        var parentBlock = clickedButton.parents('.parent-tweet-container');
        var tweetId = $(this).parents('.parent-tweet-container').attr('id');
                
        parentBlock.find('.tweet-text').show();
        $(parentBlock).find('textarea').hide();
        parentBlock.find('.buttons-edit-delete').show();
        parentBlock.find('.buttons-save-cancel').hide();
    });
    $('.button-action-save').click(function (e) {
        var clickedButton = $(e.target);
        var parentBlock = clickedButton.parents('.parent-tweet-container');
        var tweetId = $(this).parents('.parent-tweet-container').attr('id');
        var currentText = $(parentBlock).find('textarea').val();

        $.get('/Tweet/Edit', { 'id': tweetId, 'text': currentText }, function (data) { });

        $(parentBlock).find('textarea').hide();
        $(parentBlock).find('.tweet-text').text(currentText).show();
        $(parentBlock).find('.buttons-save-cancel').hide();
        $(parentBlock).find('.buttons-edit-delete').show();
    });
    $('.button-action-delete').click(function (e) {
        var tweetId = $(this).parents('.parent-tweet-container').attr('id');

        $.get('/Tweet/Delete', { 'id': tweetId }, function () { }).complete(function () {
            $.get('/Tweet/GetTweets', function (data) {
                $('#tweet-badge').html(data);
            });
        });

        $('#' + tweetId).remove();
    });

    
    var amountScrolled = 200;

    $(window).scroll(function () {
        if ($(window).scrollTop() > amountScrolled) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });

    $('.back-to-top').click(function () {
        $('body, html').animate({
            scrollTop: 0
        }, 700);
        return false;
    });

    //$('.foll').on('click',function (e) {
    //    var clickedButton = $(e.target);
    //    var parentBlock = clickedButton.parents('.users-table');
    //    var Id = $(this).parents('.users-table').attr('id');
    //    if ($(parentBlock).find('.foll').text() == 'Follow') {
    //        $(parentBlock).find('.foll').text('Unfollow');
    //        $(parentBlock).find('.foll').css('background', '#F5AB35');
    //        $(parentBlock).find('.foll').css('color', '#000');
    //    }
    //    else {
    //        $(parentBlock).find('.foll').text('Follow');
    //        $(parentBlock).find('.foll').css('background', '#3498db');
    //        $(parentBlock).find('.foll').css('color', '#fff');
    //    }
    //});

    $('#action-follow').on('click',function () {
        if($('#action-follow').text() == 'Follow this user!')
        {
                $('#action-follow').text('Unfollow this user');
                $('#action-follow').css('background', '#F5AB35');
                $('#action-follow').css('color', '#000');
            
        }
        else {
                $('#action-follow').text('Follow this user!');
                $('#action-follow').css('background', '#3498db');
                $('#action-follow').css('color', '#fff');
        }

    });
});
