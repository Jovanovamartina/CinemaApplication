

using ViewModels;

namespace Services.Abstraction
{
    public interface IMovieProgramService
    {
        List<MovieProgramViewModel> GetMoviePrograms();
        MovieProgramViewModel GetMovieProgram(int id);
        void AddMovieProgram(MovieProgramViewModel movieProgram);
        void UpdateMovieProgram(MovieProgramViewModel movieProgram);
        void DeleteMovieProgram(MovieProgramViewModel movieProgram);
    }
}
