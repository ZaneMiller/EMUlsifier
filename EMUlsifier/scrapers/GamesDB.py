import urllib as ul
import urllib2 as ul2
import elementtree.ElementTree as et
import elementtree.SimpleXMLTreeBuilder as sxtb
import re
et.XMLTreeBuilder = sxtb.TreeBuilder

class Scraper():
    def __init__(self):
        self.scraperName = "The Games DB"
        self.scraperAuthor = "Zane Miller"
        self.scraperDescription = "Gets game information from The Games DB. Supports box art, banners, and full-page art"
        self.authorHomepage = "http://www.DesignByZane.com"
        self.scraperVersion = "1.0"
        
        self._baseURL = "http://thegamesdb.net/api/"
        self._requestTimeout = 10
        
        self._platforms = {}
    
    """Makes a request to a given URL with the given params in a dict"""
    def _makeRequest(self, url, params = None):
        try:
            #GamesDB doesn't like the default header for some reason
            headers = {'User-Agent' : 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)'}
            if params:
                params = ul.urlencode(params)
            req = ul2.Request(self._baseURL + url, params, headers)
            data = ul2.urlopen(req).read()
        except ul2.HTTPError, e:
            raise Exception("HTTP Error: %d" % e.code)
        except ul2.URLError, e:
            raise Exception("URL Error: %s" % e.reason.args[1])
        else:
            return data
    
    """Parses the result from a request to get all platforms and IDs from the GamesDB"""
    def _parsePlatforms(self, data):
        platforms = {}
        root = et.fromstring(data)
        for plat in root.getiterator("Platform"):
            alias = plat.find("alias")
            if alias is not None:
                alias = alias.text.lower()
            else:
                alias = ''
            platforms[plat.find("id").text.lower()] = (plat.find("name").text.lower(), alias)
        return platforms
    
    """Finds the provided system in the list of systems provided by the GamesDB"""
    def _findSystem(self, system):
        if not self._platforms:
            self._platforms = self._parsePlatforms(self._makeRequest("GetPlatformsList.php"))
        for key in self._platforms:
            name, alias = self._platforms[key]
            if name.count(system) > 0 or alias.count(system) > 0:
                return name
    
    """Parses the result from a request to the search api"""
    def _parseSearch(self, data):
        results = {}
        root = et.fromstring(data)
        for game in root.getiterator("Game"):
            title = game.find("GameTitle").text
            year = game.find("ReleaseDate")
            if year is not None:
                title = "%s (%s)" % (title, re.findall("\d{4}", year.text)[0])
            results[game.find("id").text] = title
        return results
    
    """Returns a list of games for the given system that match the serach criteria"""
    def search(self, title, platform):
        platform = self._findSystem(platform.lower())
        #If the system isn't found return nothing
        if not platform:
            return {}
        return self._parseSearch(self._makeRequest("GetGamesList.php", {"name" : title, "platform" : platform}))
    
    """Parses the result from a request for data for a specific game"""
    def _parseInfo(self, data):
        game = {"title" : None, "genres" : [], "releaseDate" : None, "description" : None, "rating" : None, "publisher" : None, "developer" : None, "communityRating" : None}
        root = et.fromstring(data)
        root = root.find("Game")
        if root is None:
            return None
        #Title
        if root.find("GameTitle") is not None:
            game["title"] = root.find("GameTitle").text
        #Genres
        for genre in root.getiterator("genre"):
            game["genres"].append(genre.text)
        #Release Date
        if root.find("ReleaseDate") is not None:
            game["releaseDate"] = root.find("ReleaseDate").text
        #Description
        if root.find("Overview") is not None:
            game["description"] = root.find("Overview").text
        #Rating
        if root.find("ESRB") is not None:
            game["rating"] = root.find("ESRB").text
        #Publisher
        if root.find("Publisher") is not None:
            game["publisher"] = root.find("Publisher").text
        #Developer
        if root.find("Developer") is not None:
            game["developer"] = root.find("Developer").text
        return game
    
    """Request info from the GamesDB for a specific game with a given ID"""
    def getInfo(self, gameId):
        return self._parseInfo(self._makeRequest("GetGame.php", {"id" : gameId}))
    
