<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="stokBilgileri.aspx.cs" Inherits="TeknikTakip.WebForm12" %>
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
                        <label for="firstname" class="col-md-12">Stok Kodu </label>
                        <input type="text" class="form-control" id="stok_kodu_popup" runat="server">
                    </div>


                    <div class="form-group">
                        <label for="lastname" class="col-md-12">Stok Adı  </label>
                        <input type="text" class="form-control" id="stok_adi_popup" runat="server">
                    </div>


                    <div class="form-group">
                        <label  class="col-md-12">Birim  </label>
                        <input type="text" class="form-control" runat="server" id="birim_popup">
                    </div>

                    <div class="form-group">
                        <label class="col-md-12">Stok Tip Adı  </label>
                        <input type="text" id="stok_tip_adi_popup" class="form-control" runat="server">
                    </div>

                    <div class="form-group">
                        <label class="col-md-12"> Saklama Rafı </label>
                        <input type="text" id="saklamaRafi_popup" class="form-control" runat="server">
                    </div>

                    <asp:Button ID="PopUpGüncelle" class="btn btn-info" runat="server" Text="Gönder" OnClick="PopUpGüncelle_Click" />

                </div>

            </div>
        </div>
    </div>



     <div class="row text-center">
        <h2>Stok Bilgileri Ekle</h2>
    </div>
    <div class="col-md-11">
        <label class="col-md-2">Stok Kodu  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="stok_kodu" runat="server">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div class="col-md-11">
        <label class="col-md-2"> Stok Adı  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="stok_adi" runat="server">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div class="col-md-11">
        <label class="col-md-2">Birim</label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="birim">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div class="col-md-11">
        <label class="col-md-2">Stok Tip Adı  </label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="stok_tip_adi">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
        <label class="col-md-2">Saklama Rafı  </label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="saklamaRafi">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>

        
    </div>
    <div class="col-md-11">
        <div class="col-lg-3">
            <asp:Button ID="Ürün_Bilgi" class="btn btn-info te" Height="30px" Width="150" runat="server" OnClick="Ürün_Bilgi_Click" Text="Ekle" />
        </div>
        <asp:Label ID="Label6" runat="server"></asp:Label>

    </div>
    <div class="col-xs-12">
        <asp:Label ID="id" runat="server"></asp:Label>
        <asp:HiddenField ID="sec_id_HiddenField1" runat="server" />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>

                        <th class=" text-center  bg-secondary text-white">Stok Kodu</th>
                        <th class=" text-center  bg-secondary text-white">Stok Adı </th>
                        <th class=" text-center  bg-secondary text-white">Birim</th>
                        <th class=" text-center  bg-secondary text-white">Stok Tip Adı</th>  
                        <th class=" text-center  bg-secondary text-white">Saklama Rafı</th>  
                        <th class=" text-center  bg-secondary text-white">Kayit Tarihi</th> 
                        <th class=" text-center  bg-secondary text-white">Güncelleme Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Güncelle / Sil</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                           <%#Eval("Stok_Kodu") %> 
                        </td>
                        <td>
                           <%#Eval("Stok_Adi") %> 
                        </td>
                        <td>
                           <%#Eval("Birim") %> 
                        </td>
                        <td>
                           <%#Eval("Stok_Tip_Adi") %> 
                        </td>
                        <td>
                           <%#Eval("saklamaRafi") %> 
                        </td>
                        <td>
                          <%#Eval("kayit_tarihi") %> 
                        </td>
                        <td>
                           <%#Eval("güncelle_tarihi")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="Güncelle" title="Güncellemek İçin Tıklayınız" OnClick="Güncelle_Click" CssClass="fa fa-refresh" runat="server"  CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                            &nbsp;
                           &nbsp;
                            &nbsp;
                            &nbsp;
                          <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash text-danger text" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                           

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
