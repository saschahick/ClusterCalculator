   M S B A M L   `   `   `  ���� O  KClusteringCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ClusteringCalculator.ViewModelClusteringCalculator.ViewModel  %    ClusteringCalculator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     B	viewModel,clr-namespace:ClusteringCalculator.ViewModel       � Title$  ClusteringCalculator��$	��600��$
��1020�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � DataContext 2  ,ClusteringCalculator.ViewModel.MainViewModel   � 	Resources    BtnMenu �� 
TargetType �� Property �� Value  BtnAttention �� BasedOn��%�   &	        &	 O     7   '��      �� " ��.���  � ��$	 175����  � ��$ 25����  � ��$ 5q��� 8   " ��.���  � �� �	#77DC1400�� " ��.���  � ��$ 5q���  � ��$ 5q�.��� 	 � ColumnDefinitions	 �� $	��220 ��� $��* ��� $	��220 �.+��� 
 �� Orientation$
 Vertical=�.+��� $��	Init Data��.���� $
 Vertical=�.+��� $	��175��$��25��$��
0, 5, 0, 5q� �� SelectedValuePath$ Content�� �� SelectedValue �� *
SelectedDb+.@��� $��TrainDB���� $��
TwoSidesDB���� $��ChaosDB���� $��ClusterMiddleDB���� $��
RingDataDB���� #��[  ���� *CmdLoadData+���� .��	Load Data�� #��[  ���� *CmdInsertData+���� .��Insert Data�� #��[ ���� *CmdClearData+���� .��
Clear Data�� $��
Parameters��.��� 	 �� $��* ��� $��* �.+��� $��0��$��0��$��
Iterations��$��Center=��� $��1��$��0��$��Center=����� *
Iterations+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��Calculate Data��.���� $
 Vertical=�.+��� #��[  ���� *CmdRunComplete+���� .��Run Complete�� #��[  ���� *CmdRunOneIteration+���� .��Run one iteration�� $y�	Collapsed=�#��[  .��Run step by step�� $y�	Collapsed=�$��Step by step��.���� $
 Vertical=�.+��� #��[  .��
Continue�� #��[  .��Run iteration�� #��[  .��Run all iteration�� $��1��$	��510��$	��510��
�������$��10, 0, 0, 10q��� -    ��Name$ CnvData��$��1��$	��500��$	��500��
��������� -   $ CnvScale��$��1��$	��560��$	��560��
������  J� IsHitTestVisible .  �� $��2��$
 Vertical=�.+��� $��ClusterPoints��.���� $
 Vertical=�.+��� $	��175��$	��100������ *ClusterPoints+���� .R�� 	 �� $��20 ��� $��20 ��� $��5 ��� $��20 ��� $��15 ��� $��32 ��� $��5 �.+�A� $��0��$��10��$��10��$��
0, 0, 5, 0q����� *
ColorBrush+$ OneWay=��� $��1��$��Right=����� *XText+�� $��2��$��/���� $��3��$��Right=����� *YText+�� $��4��$�� [��$��Right=��� $��5��$��Right=����� *Sales.Count+�� $��6��$��]���� #��[ ���� *CmdClearClusterPoints+���� .��Clear points�� $��Information��.��� 	 �� $��* ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��
DataPoints��$��Center=��� $��1��$��0��$��Center=�$��Right=����� *Sales.Count+�� $��0��$��1��$��ClusterPoints��$��Center=��� $��1��$��1��$��Center=�$��Right=����� *ClusterPoints.Count+�� $��Export��.���� $
 Vertical=�.+��� #��[  ���� *CmdExportToImage+���� .��Export graph to image