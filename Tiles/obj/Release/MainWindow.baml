   M S B A M L   `   `   `  ���� @  <Tiles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TilesTiles      Tiles.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :xctk)http://schemas/xceed.com/wpf/xaml/toolkit     %localclr-namespace:Tiles     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xctk1)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  Tiles��$	��800��$	��350�� � 
ResizeMode$ 	CanResize=�.���  � ColumnDefinitions �� $	��120 ��� $	��200 � � RowDefinitions �� $��60 ��� $��60 ��� $��50 ��� $��60 ��� $��60 ��� $��50 ��� $��40 ��� $��50 ��� $	��90* ��� $��60 ��� $��60 ��� $��0 �.+��� $��3��$��2��
�������$��1q�$	��150��
�������$��
20,10,0,10q��� -    ��Name$ txtWidthWall��$��1��$��0��$��50��$��30��$
��Left=�$��
20,20,0,10q�
����İ�$��20(�$	��180���� -   $ txtHeightWall��$��1��$��1��$
��Left=�$��
20,10,0,20q�
����İ�$��50��$��30��$��20(�$	��200���� $��WIDTH��$��1��$��0��$��Center=�$��Center=�$��85,23,54,10q�$��20(��� $��HEIGHT��$��1��$��1��$��Center=�$��Center=�$��85,12,47,20q�$��20(��� -   $��imgPhotoWall��$��0��$��Center=�$��20,0,0,0q�$��Center=�$��90��$��90��$��2���� -    ��Name$ 	chkInvert��$��0��$��2��$��INVERT��$��Center=�$��Center=��� -   $ 	chkCenter��$��1��$��2��$��CENTER��$��Center=�$��Center=��� $��5��$��3��$��2��
�������$��1q�
�������$��	20,10,0,0q��� -   $ txtWidth��$��1��$��3��$��50��$��30��$
��Left=�$��
20,20,0,10q�
����İ�$��20(�$��30���� -   $ 	txtHeight��$��1��$��4��$
��Left=�$��
20,12,0,18q�
����İ�$��50��$��30��$��20(�$��10���� $��WIDTH��$��1��$��3��$��Center=�$��Center=�$��85,22,54,12q�$��20(��� $��HEIGHT��$��1��$��4��$��Center=�$��Center=�$��85,14,47,20q�$��20(��� -	   $��imgPhotoTile��$��0��$��3��$��Center=�$��20,0,0,0q�$��Center=�$��90��$��90��$��2���� -
    ��Name$ btnOpenImage��$��0��$��5��$��60��$��30��$��IMAGE��$��
31,5,10,15q�$��15(��� -   $ txtOpenImage��$��1��$��20(�$��5��$��30��
����İ�$��
21,5,24,15q��� -    ��Name$ sldFuga��$��6��$��2��$��Center=� � Minimum$ 0Q�	 � Maximum$	 6Q�
 � Value$
 0Q� �� TickFrequency$ 2Q�$	��281��$
��Left=�$��31,0,0,6q� �� IsSnapToTickEnabled .  �� TickPlacement$ BottomRight=�
���   �#  Xceed.Wpf.Toolkit.ColorPicker  -   $��clpFuga��$��2��$��7��!   AvailableColorsSortingMode$ HueSaturationBrightness=�   DisplayColorAndName .    ShowStandardColors .  $��20,0,0,0q��� -    ��Name$ brdImage��$��10,10,10,10q�$��2��$��8��$��0q�
�������$��Center=�$��Center=�._��� -   $��imgPhoto��$��Uniform=��� -   $ btnGenerate��$��Center=�$	��290��$��GENERATE��$��30�����	#FFDCDBD9$��15(�$��2��$��9��$��Center=�$��
20,20,2,10q��� -   $ btnAdd��$	��ADD��$��30�����	#FFDCDBD9$��15(�$��0��$��10��$��2��$��
26,0,72,30q��� -   $ 
txtTileCnt��
����İ�$��20(�$��30��$��1��$��10��$��60��$
��Left=�$��
134,0,0,30q�