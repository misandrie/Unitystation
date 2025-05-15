// SPDX-FileCopyrightText: 2024 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 BombasterDS <deniskaporoshok@gmail.com>
// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Client.UserInterface;

namespace Content.Goobstation.Client.CEF;

public sealed class BrowserWindowBoundUserInterface(EntityUid owner, Enum uiKey) : BoundUserInterface(owner, uiKey)
{
    [ViewVariables]
    private BrowserWindow? _window;
    protected override void Open()
    {
        base.Open();
        IoCManager.InjectDependencies(this);
        _window = this.CreateWindow<BrowserWindow>();
    }

}
