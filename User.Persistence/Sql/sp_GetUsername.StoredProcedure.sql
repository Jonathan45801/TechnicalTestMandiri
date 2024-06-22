create procedure GetUsername 
@token varchar(88)
as

select a.Id,a.UserName from UserLogin (nolock) a inner join UserLoginToken (nolock) b on a.Id = b.UserLoginId
where b.AuthToken = @token