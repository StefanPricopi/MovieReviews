function AddComment() {
     var reviewId = document.getElementById('reviewId').value;
    var commentDescription = document.getElementById('commentText').value;

    var data = {
        reviewId: reviewId,
        commentDescription: commentDescription
    };

    fetch('/ReviewDetails/OnGetAddComment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (response.ok) {
                // Refresh comments after adding
                RefreshComments();
            } else {
                console.error('Failed to add comment');
            }
        })
        .catch(error => {
            console.error('Error adding comment:', error);
        });
}

function RefreshComments() {
    var reviewId = document.getElementById('reviewId').value;

    fetch(`/ReviewDetails/RefreshComments?reviewID=${reviewId}`)
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Failed to fetch comments');
            }
        })
        .then(data => {
            // Update comments in the UI
            var commentsList = document.getElementById('commentsList');
            commentsList.innerHTML = '';

            data.forEach(comment => {
                var commentDiv = document.createElement('div');
                commentDiv.textContent = comment.CommentDescription;
                commentsList.appendChild(commentDiv);
            });
        })
        .catch(error => {
            console.error('Error refreshing comments:', error);
        });
}