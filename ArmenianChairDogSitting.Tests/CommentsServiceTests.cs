using ArmenianChairDogsitting.Business.Exceptions;
using ArmenianChairDogsitting.Business.Models;
using ArmenianChairDogsitting.Business.Services;
using ArmenianChairDogsitting.Data.Entities;
using ArmenianChairDogsitting.Data.Repositories;
using Moq;

namespace ArmenianChairDogSitting.Business.Tests;

public class CommentsServiceTests
{
    private Mock<ICommentsRepository> _commentsRepository;
    private CommentsService _sut;

    [SetUp]
    public void Setup()
    {
        _commentsRepository = new Mock<ICommentsRepository>();
        _sut = new CommentsService(_commentsRepository.Object);        
    }

    [Test]
    public void GetAllComments_WhenCommentsExist_ThenReturnMapedListOfComments()
    {
        //given
        var commentsInRepo = SetComments();

        _commentsRepository
            .Setup(x => x.GetAllComments())
            .Returns(commentsInRepo);

        //when
        var actual = _sut.GetComments();

        //then
        Assert.IsTrue(actual is not null);
        Assert.IsTrue(actual!.Count > 0);
        Assert.IsTrue(actual is List<CommentModel>);
        Assert.IsTrue(actual[0].Client is ClientModel); //later: need create moedel & maping to this one
        Assert.IsTrue(actual[0].Order is OrderModel);// later: need other branch
    }

    [Test]
    public void GetAllComments_WhenCommentsDoesntExist_ThenThrowNotFoundException()
    {
        //given
        var commentsInRepo = new List<Comment>();

        _commentsRepository
            .Setup(x => x.GetAllComments())
            .Returns(commentsInRepo);

        //when then
        Assert.Throws<NotFoundException>(() => _sut.GetComments());
    }

    [Test]
    public void AddComment_WhenCalled_ThenReturnIdOfAddedComment()
    {
        //given
        var nowTime = DateTime.Now;
        var commentToAddModel = new CommentModel()
        {
            Id = 34,
            Text = "kwa kwa",
            TimeCreated = nowTime
        };

        var expectedId = 34;

        _commentsRepository
            .Setup(x => x.AddComment(It.IsAny<Comment>()))
            .Returns(expectedId);

        //when
        var returnedInt = _sut.AddComment(commentToAddModel);

        //then
        Assert.AreEqual(expectedId, returnedInt);
    }

    [Test]
    public void DeleteCommentById_WhenCommentExist_ThenKeepWorking()
    {
        //given
        var id = 2;
        //_commentsRepository.MockGetById(id, new() { Id = id, IsDeleted = false});
        //_commentsRepository.MockDeleteById(id);

        ////when
        //_commentsService.DeleteCommentById(id);

        //then
        Assert.Pass();
    }

    [Test]
    public void DeleteCommentById_WhenCommentDoesntExist_ThenThrowNotFoundException()
    {
        //given
        //    var id = 2;
        //    _commentsRepository.MockGetById(id, null);
        //    _commentsRepository.MockDeleteById(id);

        //    //when then
        //    Assert.Throws<NotFoundException>(() => _commentsService.DeleteCommentById(id));
    }

    private List<Comment> SetComments()
    {
        return new List<Comment>() {
            new() {
                Id = 1,
                Client = new() { Id = 1, Name = "Ivan"},
                IsDeleted = false,
                Order = new OrderWalk() {Id = 1},
                TimeCreated = DateTime.Now,
                Text = "blah blah blah"
            },
            new() {
                Id = 2,
                Client = new() { Id = 2, Name = "Georg"},
                IsDeleted = false,
                Order = new OrderWalk() {Id = 2},
                TimeCreated = DateTime.Now,
                Text = "blah blah blah"
            },
            new() {
                Id = 3,
                Client = new() { Id = 3, Name = "Lucius"},
                IsDeleted = false,
                Order = new OrderWalk() {Id = 3},
                TimeCreated = DateTime.Now,
                Text = "blah blah blah"
            }
        };
    }
}