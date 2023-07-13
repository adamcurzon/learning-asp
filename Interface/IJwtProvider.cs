using System;
using learning_asp.Model;

namespace learning_asp.Interface
{
	public interface IJwtProvider
	{
		string Generate(User user);
	}
}

