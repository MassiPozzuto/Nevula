    <div class="container__all">
        <div class="container__data">
            <div class="container__logo">
                <img src="../img/logo_empresa_jotelson.png" alt="Logo Nevula" width="300px">
            </div>

            <div class="container__title">
                <p>Inicia sesión en Nevula</p>
            </div>

            <form method="POST" action="../controllers/login.php" id="form" class="login__form">

                <div class="form-group">
                    <label for="email" class="input-title">Dirección de correo</label>
                    <input type="email" name="email" class="" value="<?php echo (isset($_COOKIE['email']) ? $_COOKIE['email'] : ''); ?>">
                </div>

                <div class="form-group">
                    <label for="password" class="input-title">Contraseña</label>
                    <div class="container__password">
                        <input class="pass" id="password" type="password" name="password" value="<?php echo (isset($_COOKIE['password']) ? $_COOKIE['password'] : ''); ?>">
                        <button type="button" class="btn-view-password toggle-password" toggle="#password">
                            <span class="icon"><i class="bi bi-eye-fill"></i></span>
                        </button>
                    </div>
                    <div class="msj_error">
                        <?php echo (isset($error) ? $error : ''); ?>
                    </div>
                </div>

                <div class="form-group remember-forgot">
                    <div>
                        <label class="label__remember">Recordarme
                            <input type="checkbox" id="remember" name="remember" value="1" checked>
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    <div class="container__forgot">
                        <a class="links" href="#forgotpassword">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>

                <div class="form-group">
                    <button type="submit" class="" id="login-submit">Iniciar sesión</button>
                </div>

            </form>

            <div class="container__separator">
                <div class="separator-line">
                    <hr>
                </div>
                <div class="separator-letter">
                    <span>O</span>
                </div>
                <div class="separator-line">
                    <hr>
                </div>
            </div>

            <p class="text-create-account">¿No tenés cuenta? <a class="links" href="register.php">Registrarse</a></p>


        </div>
    </div>

    <script src="../js/password.js" type="text/javascript"></script>