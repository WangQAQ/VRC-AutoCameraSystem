# VRC自动导播系统
> 该项目已停止维护
---
#### 这是一个通过UDON同步实现的导播系统，它可以让在一台电脑上操作机位，在另一台电脑上开满画质用于直播
#### 适用于各种需要直播的活动
* 使用场景：
  *  你需要带着VR参与活动，但是因为性能不够而无法直播
  *  你需要非常多的机位
  *  你需要一个音频插件来放大一个区域玩家的声音
  *  你想要一个很好的运镜来跟踪玩家
  *  你想在直播时候切出游戏内ProTV播放视频
#### 如果你有以上需求，那么恭喜你，这个插件会非常适合你

> 目前为早期测试，可能会有BUG

#### 这里是安装说明书

[说明书](https://github.com/WangQAQ123/VRC-AutoCameraSystem/blob/function/main/WangQAQ/AutoCameraSystem/Doc/%E4%BD%BF%E7%94%A8%E8%AF%B4%E6%98%8E.md)

#### 安装完成后只需要走进视角球（用于直播的客户端），然后即可在其他客户端上操作机位
#### 它的基本原理是使用 Render Texture 和 全屏Shader

> 注意在使用时请不要将用于直播的客户端的位置放得过于靠近边缘，防止使用其他插件时无法正确显示

![Img](https://github.com/WangQAQ123/VRC-AutoCameraSystem/blob/function/Img/R9.png)

---
## 使用的资源
* Shader : https://github.com/ganlvtech/vrchat-screen-space-camera-render-texture
* ButtonUI C# : PoolParlorTablePrefab1.0.4c
