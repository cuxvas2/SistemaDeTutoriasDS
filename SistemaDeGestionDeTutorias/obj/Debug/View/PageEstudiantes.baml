   M S B A M L   `   `   `  ����U  QSistemaDeGestionDeTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SistemaDeGestionDeTutoriasSistemaDeGestionDeTutorias  5      0    *SistemaDeGestionDeTutorias.PageEstudiantes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:SistemaDeGestionDeTutorias     5        N� Title$  Page1��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $��42 �6   6*   �� 5      $��42 �6   6*   �� 5      6   �� 5      $��42 �6   6*   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DG��5         AutoGenerateColumns .     
IsReadOnly . $��0��6K   $��2��6[      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Matricula��6%      MaxWidth$	 100Q�6Q      CanUserResize .  	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6v   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *Name+6�     5      $ Nombre��6%    .  $	 80 6d   
 66   �� *Age+6q     5      $ Apellido Paterno��6%    .  
 6@   �� *Age+6p     5      $ Apellido Materno��6%    .  
 6@   �� *Age+6p     5      $ Correo Institucional��6%    .  $
	 Auto 6r   
 6D   �� *Age+6�     5      $ Correo Personal��6%    .  $
	 Auto 6m   
 6?   �� *Age+6|     5      $ Programa Educativo��6%    .  
 6B   �� *Age+6r     5       $ Tutor Academico��6%    .  
 6?   �� *Age+6o   5"      	� 5#   
   -   5         	�Name$ RadioLIS��5#      $	��LIS��6(   $
��Left=�66   $��	275,0,0,0q�6Q   $��Center=�6d   	� 5$   
   -   5        $ 
RadioLICIC��5$      $��LICIC��6*   $
��Left=�6:   $��	350,0,0,0q�6U   $��Center=�6h   	� 5%   
   -   5        $ 
RadioLISTI��5%      $��LISTI��6*   $
��Left=�6:   $��	425,0,0,0q�6U   $��Center=�6h   	� 5&   
   -   5        $ 	RadioLEST��5&      $
��LEST��6)   $
��Left=�68   $��	575,0,0,0q�6S   $��Center=�6f    J� RenderTransformOrigin$ 0.906,0.663&�6�   	� 5'   
   -   5        $ 	RadioLRSC��5'      $
��LRSC��6)   $
��Left=�68   $��	500,0,0,0q�6S   $��Center=�6f   	� 5(   
   -   5        $ RadioLTC��5(      $	��LTC��6(   $
��Left=�66   $��	650,0,0,0q�6Q   $��Center=�6d   	� 5)   
   -   5        $ 
RadioTODOS��5)      $��TODOS��6*   $
��Left=�6:   $��	725,0,0,0q�6U   $��Center=�6h   �� 5*   
   $��	Programa:��6   $
��Left=�6$   $��10,6,0,0q�6?   $	��Top=�6Q   �� 5+   
   -	   5         ��Name$ 	Matricula��5+      $
��Left=�6%   $��10,0,0,0q�6@   $��1��6R    �� TextWrapping$
 Wrap=�6_   $��	Matricula��6s   $��Center=�6�   $	��304��6�   �� 5,   
   -
   5         ��Name$ BotonBuscar��5,      $��BUSCAR��6&   $
��Left=�67   $��	330,0,0,0q�6R   $��1��6e   $��Center=�6r   $��95��6�   �� 5-   
   -   5        $ BotonEliminar��5-      $��Eliminar��6(   $
��Left=�6;   $��
566,10,0,0q�6V   $��3��6j   $	��Top=�6w   {�.  $��70��6�   �� 5.   
   -   5        $ 
BotonNuevo��5.      $��Nuevo��6%   $
��Left=�65   $��
713,10,0,0q�6P   $��3��6d   $	��Top=�6q   $��70��6�   �� 5/   
   -   5        $ BotonModificar��5/      $��	Modificar��6)   $
��Left=�6=   $��
641,10,0,0q�6X   $��3��6l   $	��Top=�6y   $��67��6�   {�.  6�   51      52      