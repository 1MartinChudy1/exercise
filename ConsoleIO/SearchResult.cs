using System.Collections;
using System.Collections.Generic;

namespace Main
{
    public class SearchResult : OperationResult
    {
        public SearchResult(int fileCount, IEnumerable<IFile> searchedFiles)
            :base(fileCount)
        {
            SearchedFiles = $"Files:\n{GetFileNames(searchedFiles)}";
        }

        public string SearchedFiles { get; }

        private string GetFileNames(IEnumerable<IFile> searchedFiles)
        {
            var result = string.Empty;

            foreach (var file in searchedFiles)
            {
                result += $"{file.Name}\n";
            }

            return result;
        }
    }
}