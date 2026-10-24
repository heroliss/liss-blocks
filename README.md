# Liss Blocks · 方块之间

将 2015 年俄罗斯方块半成品补完的 Windows 桌面游戏。七种方块、清晰的落点预览、暂存与下一组方块，配合深色双缓冲棋盘与完整的游戏循环。

## 开始游戏

Windows x64 解压后运行 `Liss.Blocks.exe`；无需安装 .NET 或额外资源。

| 操作 | 按键 |
| --- | --- |
| 左右移动 | `←` / `→`，长按连续移动 |
| 加速下落 | `↓` |
| 顺时针旋转 | `↑` 或 `X` |
| 逆时针旋转 | `Z` |
| 直接落地 | `Space` |
| 暂存 / 交换 | `C`，每次落块前可用一次 |
| 暂停 / 继续 | `P` 或 `Esc` |
| 新的一局 | `R` |

点击“练习局”从一组固定的堆叠开始练习；计分和消行数从零开始。切到其他窗口会自动暂停。新局不继承旧棋盘；游戏记录目前不跨启动保存。

## 规则与实现

- **10 × 20 可见棋盘**，另有 2 行出生缓冲区；锁定后触及顶端缓冲区则结束。
- **7-bag 随机袋**：每组七个方块各出现一次；预览后续五个方块。
- **碰撞与旋转**：四格几何独立于绘图；左右与上方补偿用于贴墙旋转，顺逆时针都可用。采用简化踢墙，不声称完整实现官方 SRS。
- **消行计分**：单次 1 / 2 / 3 / 4 行分别得到 100 / 300 / 500 / 800 × 当前等级；软降每格 1 分，硬降每格 2 分。每消除 10 行升一级。
- **单 UI 线程时钟**：WinForms 定时器只推进状态，Stopwatch 控制重力与按键连发；没有旧计时线程直接绘图的资源竞争。
- **状态驱动渲染**：双缓冲重绘棋盘、活动方块、落点、暂存、预览与暂停遮罩；所有图形由代码绘制，不使用未知许可素材。

这是原创学习游戏的现代恢复版本，与 Tetris 品牌或官方产品无关联。

## 开发与校验

需要 Windows 与 .NET 10 SDK。

```powershell
dotnet build src/Blocks.App/Blocks.App.csproj -c Release
dotnet run --project tests/Blocks.Checks -c Release
powershell -ExecutionPolicy Bypass -File scripts/publish.ps1
```

核心测试覆盖所有方块旋转、墙边碰撞、7-bag、固定种子、暂存限制、暂停、落点、四行同时消除、计分和重开，并执行 300 场随机动作对局检查状态不变量。

`Liss.Blocks.exe --showcase` 进入同一个真实练习局并先暂停，按 `P` 继续，方便复现展示画面。

## 历史来源

`legacy/2015-original` 保留原有 `Block`、`BlockGroup`、`Palette`、配置与窗口源码，`legacy/manifest.json` 记录字节校验。现代版本重建游戏状态与渲染，延续原自写方块模型与桌面操作目标；没有复制旧 bin/obj 或用户文件。

运行时 .NET / Windows Forms 使用 MIT 许可，详见 [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md)。仓库没有为原创源码额外授予开源许可证。
