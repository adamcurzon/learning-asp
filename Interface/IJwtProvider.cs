using System;
namespace learning_asp.Interface
{
	public interface IJwtProvider
	{
		string Generate(string input);
	}
}

