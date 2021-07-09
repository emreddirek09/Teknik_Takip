<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="cihazEkle.aspx.cs" Inherits="TeknikTakip.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        <script type="text/javascript">
            function Gonder() {
                $('#myModal').modal('show');
            }
        </script>

    <div class="col-xs-12  ">
        <!--Burada da butona tıklayınca gelecek olan  Bootstrap modal ı ekliyoruz -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="form-group">
                        <label for="firstname" class="col-md-12">Marka  </label>
                        <input type="text" class="form-control" id="marka_popup" runat="server">
                    </div>


                    <div class="form-group">
                        <label for="lastname" class="col-md-12">Model  </label>
                        <input type="text" class="form-control" id="modeli_popup" runat="server">
                    </div>


                    <div class="form-group">
                        <label  class="col-md-12">Aksesuar  </label>
                        <input type="text" class="form-control" runat="server" id="aksesuar_popup">
                    </div>



                    <div class="form-group">
                        <label for="password" class="col-md-12">Seri No  </label>
                        <input type="text" id="seriNo_popup" class="form-control" runat="server">
                    </div>


                    <div class="form-group">
                        <label class="col-md-12"> Adaptör No </label>
                        <input type="text" class="form-control" id="adaptörNo_popup" runat="server">
                    </div>


                    <div class="form-group">
                        <label class="col-md-12">Batarya No</label>
                        <input type="text" class="form-control" id="bataryaNo_popup" runat="server">
                    </div>



                    <asp:Button ID="PopUpGüncelle" class="btn btn-info" runat="server" Text="Gönder" OnClick="PopUpGüncelle_Click" />

                </div>

            </div>
        </div>
    </div>



     <div class="row text-center">
        <h2>Cihaz Ekle</h2>
    </div>
    <div class="col-md-11">
            <label for="müsteri" class="col-md-2">Müşteri Seç  </label>
            <div class="col-md-9">
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Height="50px" Width="250">
                    <asp:ListItem Enabled="true">Seçiniz</asp:ListItem> </asp:DropDownList>

            </div>
            <label for="firstname" class="col-md-2">Markası  </label>
            <div class="col-md-9">
                <input type="text" class="form-control" runat="server" id="marka" placeholder="Markasını Giriniz.">
            </div>
        </div>

        <div class="col-md-11">
            <label for="lastname" class="col-md-2">Modeli  </label>
            <div class="col-md-9">
                <input type="text" class="form-control" runat="server" id="modeli" placeholder="Modelini Giriniz.">
            </div>

        </div>

    <div class="col-md-11">
            <label for="müsteri" class="col-md-2">Aksesuar Durumu  </label>
            <div class="col-md-9">
               <input class="form-control" runat="server" id="aksesuarDurumu" placeholder="Aksesuar Durumunu Giriniz. ">

            </div>
            
         <label class="col-md-2">Batarya Seri No  </label>
            <div class="col-md-9">
                <input class="form-control" runat="server" id="bataryaSeriNo" placeholder="Batarya Seri No Giriniz. ">
            </div>


        </div>

        <div class="col-md-11">
            <label for="lastname" class="col-md-2">Adaptör Seri No  </label>
            <div class="col-md-9">
                <input class="form-control" runat="server" id="adaptörSeriNo" placeholder="Adaptör Seri No Giriniz. ">
            </div>

        </div>

        <div class="col-md-11">
            <label for="firstname" class="col-md-2">Cihaz Seri No  </label>
            <div class="col-md-9">
                 <input class="form-control" runat="server" id="seriNo" placeholder="Seri No Giriniz. ">
            </div>
           

        </div> 
        <div class="col-md-11">

            <div class="col-lg-3">
                <asp:Button ID="Ekle" class="btn btn-info text-center" Height="30px" Width="150" runat="server" Text="Ekle"  OnClick="Ekle_Click"/>

            </div>

        </div>
    <div class="row">
        <div class="col" style="text-align: center;">
             <label> Firma Adı Giriniz</label>
            <asp:TextBox CssClass="form-control container text-center" type="text" style="height:20px; width:250px;" ID="searchInput"  AutoCompleteType="Disabled" placeholder="Arama"  runat="server"></asp:TextBox>          
            <asp:LinkButton ID="searchButton" CssClass="fa fa-search" runat="server" OnClick="searchButton_Click"></asp:LinkButton>
        </div>
    </div>

        <div class="col-xs-12 container">
            <asp:Label ID="id" runat="server"></asp:Label>
            <asp:HiddenField ID="sec_id_HiddenField1" runat="server" />
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered table-hover text-center">
                        <thead>                            
                            <th class=" text-center  bg-secondary text-white">Kayıt Eden </th>
                            <%--<th class=" text-center  bg-secondary text-white">Cihaz Id</th>--%>
                            <th class=" text-center  bg-secondary text-white">Firma Adı</th>
                            <th class=" text-center  bg-secondary text-white">Markasi</th>
                            <th class=" text-center  bg-secondary text-white">Modeli</th>
                            <th class=" text-center  bg-secondary text-white">Seri NO</th>
                            <th class=" text-center  bg-secondary text-white">Adaptör No</th>
                            <th class=" text-center  bg-secondary text-white">Batarya No</th>                            
                            <th class=" text-center  bg-secondary text-white">Aksesuar Durumu</th>
                            <th class=" text-center  bg-secondary text-white">Kayıt Tarihi</th>
                             <th class=" text-center  bg-secondary text-white">Güncelle</th>
                            <th class=" text-center  bg-secondary text-white">Sil</th>

                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                           
                            <td>
                               <%#Eval("kayitEden_id") %> 
                            </td>
                            <%--<td>
                                <%#Eval("Id") %>
                            </td>--%>
                            <td>
                                <%#Eval("firma_adi") %> 
                            </td>
                            <td>
                                <%#Eval("markasi") %> 
                            </td>
                            <td>
                                <%#Eval("modeli") %> 
                            </td>
                            <td>
                               <%#Eval("seriNo") %>
                            </td>
                            <td>
                                <%#Eval("adaptörNo") %> 
                            </td>
                            <td>
                             <%#Eval("bataryaSeriNo") %> 
                            </td>
                            <td>
                               <%#Eval("aksesuarDurumu") %> 
                            </td>
                            <td>
                                <%#Eval("kayit_tarihi")%>
                            </td>
                            <td>
                                <asp:LinkButton ID="Güncelle" type="submit" runat="server" CssClass=" fa fa-refresh" OnClick="Güncelle_Click1"  CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>

                            </td>
                            <td>
                                <asp:LinkButton ID="sil" OnClick="sil_Click1" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                            </td>

                        </tr>
                    </tbody>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </div>


</asp:Content>
