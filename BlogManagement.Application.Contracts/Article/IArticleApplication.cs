using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OperationResult CreateArticle(CreateArticle command);
        OperationResult EditArticle(EditArticle command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
        OperationResult Active(long id);
        OperationResult InActive(long id);
        void AddNumView(long id);
        void AddNumVote(long id);

    }
}
