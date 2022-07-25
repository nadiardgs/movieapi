This project defines a movie API from the data available at the public OMDB API (http://www.omdbapi.com).
There are five available routes.

/all
This route shows all the movies registered in the user database.
Pre conditions: none
Arguments: nome
Returns:	OK
Example: http://localhost:{id}/all


/new
This route creates a new move in the user database.
Pre conditions: the informed IMDB id must necessarily exist in the public OMDB API;
				the movie must not already exist in the user database.
Arguments: ImdbId (required), watched (whether the user watched the movie or not) (required), userScore (required)
Returns:	OK -> when the movie is created successfully; 
			NotFound -> when the informed IMDB id does not exist in the public OMDB API;
			BadRequest -> when the movie already exists in the user database.
Example: http://localhost:{id}/new?idImdb=tt0897098&watched=true&userScore=7.8

/{imdbId}
This route shows a movie by its IMDB id.
Pre conditions: the informed IMDB id must necessarily exist in the user database.
Arguments: ImdbId (required)
Returns:	OK -> when the movie is shown successfully;
			NotFound -> when the informed IMDB id doesn't exist in the user database.
Example: http://localhost:{id}/tt0897098


/edit/{imdbId}
This route edits an existing movie by its IMDB id.
Pre conditions: the informed IMDB id must necessarily exist in the user database.
Arguments: ImdbId (required), name (optional), description (optional), watched (optional but false if not informed), userScore (optional)
Returns:	OK -> when the movie is edited successfully;
			NotFound -> when the informed IMDB id doesn't exist in the user database.
Example: http://localhost:{id}/edit/tt0897098?name=Under%20the%20Knife%20-%20Reloaded&watched=true
		
		
/delete/{imdbId}
This route deletes an existing movie by its IMDB id.
Pre conditions: the informed IMDB id must necessarily exist in the user database.
Arguments: ImdbId (required)
Returns:	OK -> when the movie is deleted successfully;
			NotFound -> when the informed IMDB id doesn't exist in the user database.
Example: http://localhost:{id}/delete/tt0897098