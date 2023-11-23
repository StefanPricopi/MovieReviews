// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addComment() {
    var reviewId = document.getElementById('reviewId').value;
    var commentText = document.getElementById('commentText').value;

    // Prepare the data to be sent
    var data = {
        reviewId: reviewId,
        commentDescription: commentText
    };

    // Make a POST request to submit the comment
    fetch('/ReviewDetails/AddComment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (response.ok) {
                // Handle success (e.g., refresh comments)
                refreshComments();
            } else {
                // Handle failure
                console.error('Failed to add comment');
            }
        })
        .catch(error => {
            console.error('Error adding comment:', error);
        });
}