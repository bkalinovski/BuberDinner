﻿using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Domain.MenuAggregate.Menu user);
}