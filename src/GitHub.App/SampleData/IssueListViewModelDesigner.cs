using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using GitHub.Models;
using GitHub.ViewModels;
using GitHub.ViewModels.GitHubPane;

namespace GitHub.SampleData
{
    [ExcludeFromCodeCoverage]
    public class IssueListViewModelDesigner : PanePageViewModelBase, IIssueListViewModel
    {
        public IssueListViewModelDesigner()
        {
            var issues = new[]
            {
                new IssueListModel
                {
                    Number = 1481,
                    Title = "When creating new pull request enable GitHub button",
                    Author = new ActorModel { Login = "meaghanlewis" },
                    UpdatedAt = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(1)),
                },
                new IssueListModel
                {
                    Number = 1482,
                    Title = "Add Issue Management to Visual Studio",
                    Author = new ActorModel { Login = "drobertson123" },
                    UpdatedAt = DateTimeOffset.Now.Subtract(TimeSpan.FromMinutes(2)),
                },
                new IssueListModel
                {
                    Number = 1489,
                    Title = "Make Packages AsyncPackages",
                    Author = new ActorModel { Login = "grokys" },
                    UpdatedAt = DateTimeOffset.Now.Subtract(TimeSpan.FromHours(5)),
                },
            };

            Issues = issues.Select(x => new IssueListItemViewModel(x)).ToList();
        }

        public IUserFilterViewModel AuthorFilter { get; set; }
        public IUserFilterViewModel AssigneeFilter { get; set; }
        public IReadOnlyList<IIssueListItemViewModel> Issues { get; }
        public string SearchQuery { get; set; }
        public string SelectedAssignee { get; set; }
        public string SelectedAuthor { get; set; }
        public IReadOnlyList<IssueStateFilter> States { get; }
        public IssueStateFilter SelectedState { get; set; }

        public Uri WebUrl { get; }
        public Task InitializeAsync(ILocalRepositoryModel repository, IConnection connection) => Task.CompletedTask;
    }
}