using System;
using System.Collections.Generic;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Core.Domain.Visits;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class PostApplicationService
    {
          private readonly PostRepository _postRepository;
          private readonly VisitRepository _visitRepository;
       
        public PostApplicationService(PostRepository postRepository,VisitRepository visitRepositoryy)
        {
            _postRepository = postRepository;
             _visitRepository = visitRepositoryy;
        }

        public void Add(AddPostCommand post)
        {
            _postRepository.Add(post.ToPost());
        }

        public PostCommentModel Get(int postId)
        {
            _visitRepository.Add(new Visit { PostId = postId, CreatedOn = DateTime.Now });
            var post = _postRepository.Get(postId);
            return new PostCommentModel
            {
                Title = post.Title,
                Description = post.Description,
                BlogId = post.BlogId,
                Comments = post.Comments,
                VisitCount = post.Visits.Count
            };
        }

        public ICollection<Post> Get()
        {
            return _postRepository.Get();
        }

        public void Remove(int PostId)
        {
            _postRepository.Remove(PostId);
        }
    }
        
    }