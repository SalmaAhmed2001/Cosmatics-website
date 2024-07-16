﻿using EcommercePro.DTO;
using EcommercePro.Models;
using EcommercePro.Repositiories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EcommercePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteReviewController : ControllerBase
    {
        IWebsiteReview websiteReview;

        public WebsiteReviewController(IWebsiteReview WebsiteReview1)
        {
            websiteReview = WebsiteReview1;
        }

        [HttpGet]
        public ActionResult<List<DisplayReviews>> GetAll()
        {
            List<WebsiteReview> reviewList = websiteReview.GetAll();

            List<DisplayReviews> reviews = reviewList.OrderBy(r=>r.CreatedDate).Select(review => new DisplayReviews()
            {
                id=review.Id,
                Comment=review.Comment,
                userimage=review.User.Image,
                username=review.User.UserName,
                CreatedDate=(DateOnly)review.CreatedDate,
                Rating=review.Rating


            }).ToList();

            return reviews;

        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(WebsiteDTO newReview)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    websiteReview.Insert(new WebsiteReview()
                    {
                        Rating = newReview.Rating,
                        Comment = newReview.Comment,
                        UserId = newReview.UserId,
                        CreatedDate = DateOnly.FromDateTime(DateTime.Now)
                    });
                    websiteReview.Save();

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while adding the review. Please try again later.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int reviewId)
        {
            bool isDeleted = this.websiteReview.Delete(reviewId);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest("Faild to Delete");
        }

    }
}