async function AddComment() {
    try {
        var reviewId = document.getElementById('reviewId').value;
        var commentDescription = document.getElementById('commentText').value;
        var data = {
            reviewId: reviewId,
            commentDescription: commentDescription,
            
        };

        const response = await fetch('/ReviewDetails/AddComment', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });
        console.log(response.status);
        if (response.ok) {
            // Refresh comments after adding
            await RefreshComments();
        } else {
            console.error('Failed to add comment');
        }
    } catch (error) {
        console.error('Error adding comment:', error);
    }
}

async function RefreshComments() {
    try {
        var reviewId = document.getElementById('reviewId').value;

        const response = await fetch(`/ReviewDetails/RefreshComments?reviewID=${reviewId}`);

        if (response.ok) {
            const data = await response.json();

            // Update comments in the UI
            var commentsList = document.getElementById('commentsList');
            commentsList.innerHTML = '';

            data.forEach(comment => {
                var commentDiv = document.createElement('div');
                commentDiv.textContent = comment.CommentDescription;
                commentsList.appendChild(commentDiv);
            });
        } else {
            throw new Error('Failed to fetch comments');
        }
    } catch (error) {
        console.error('Error refreshing comments:', error);
    }
}
console.log('mediaData:', @Html.Raw(Json.Serialize(Model.Top5LikedMedia)));


