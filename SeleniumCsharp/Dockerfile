# Use the official .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the csproj and restore dependencies
COPY SeleniumCSharp.csproj ./ 
RUN dotnet restore  

# Copy the rest of the code
COPY ./ ./ 
RUN dotnet publish SeleniumCSharp.csproj -c Release -o out

# Use the official .NET 8.0 runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory in the runtime image
WORKDIR /app
COPY --from=build-env /app/out ./ 

# Install required dependencies
RUN apt-get update && apt-get install -y \
    wget \
    curl \  
    unzip \
    libxss1 \
    libappindicator3-1 \
    libgconf-2-4 \
    libglib2.0-0 \
    libnss3 \
    libx11-xcb1 \
    libxcomposite1 \
    libxcursor1 \
    libxi6 \
    libxtst6 \
    libxrandr2 \
    gnupg2 \  
    && apt-get clean


# Install Google Chrome
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google-chrome.list && \
    apt-get update && \
    apt-get install -y google-chrome-stable && \
    apt-get clean

# Install a fixed version of ChromeDriver that matches your Chrome version
ENV CHROMEDRIVER_VERSION=129.0.6668.70 
RUN wget -q -O /tmp/chromedriver.zip https://chromedriver.storage.googleapis.com/$CHROMEDRIVER_VERSION/chromedriver_linux64.zip && \
    unzip /tmp/chromedriver.zip -d /usr/local/bin/ && \
    chmod +x /usr/local/bin/chromedriver && \
    rm /tmp/chromedriver.zip

# Set environment variables for Chrome and ChromeDriver
ENV CHROME_BIN=/usr/bin/google-chrome
ENV CHROME_PATH=/usr/bin/google-chrome
ENV PATH=$PATH:/usr/local/bin

# Set the entry point for the container to run tests
ENTRYPOINT ["dotnet", "test", "/app/TestsOut/YourTestProject.dll"]

